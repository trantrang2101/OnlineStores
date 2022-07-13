using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Project.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Invoice(int id)
        {
            dynamic model = new ExpandoObject();
            model.Bill = ADO.BillADO.GetBill(id);
            return View(model);
        }

        public IActionResult List()
        {
            dynamic model = new ExpandoObject();
            List<Bill> list = new List<Bill>();
            string userJson = HttpContext.Session.GetString("user");
            if(!string.IsNullOrEmpty(userJson))
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                list = ADO.BillADO.GetList(null, user.Id);
            }
            else
            {
                string bill = HttpContext.Session.GetString("RecentBill");
                if (bill != null)
                {
                    list = JsonConvert.DeserializeObject<List<Bill>>(bill);
                }
            }
            model.List = list;
            return View(model);
        }
        public IActionResult CheckOut()
        {
            Dictionary<int, int> Cart = new Dictionary<int, int>();
            string cartStr = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrEmpty(cartStr))
            {
                Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
            }
            else
            {
                return RedirectToAction("List","Cart");
            }
            Dictionary<Product, int> list = new Dictionary<Product, int>();
            foreach (int key in Cart.Keys)
            {
                list.Add(ADO.ProductADO.GetProduct(key, true), Cart[key]);
            }
            List<BillStatus> statuses = ADO.BillStatusADO.GetList(true);
            var listGroup = list.GroupBy(x => x.Key.RestaurantId).ToDictionary(x => x.Key, y => y.ToDictionary(x => x.Key, y => y.Value));
            //string temp = "";
            //foreach (string key in Request.Form.Keys)
            //{
            //    temp+=key+"="+Request.Form[key]+"&";
            //}
            bool isTakeAway = !string.IsNullOrEmpty(Request.Form["isTakeAway"])&& Request.Form["isTakeAway"].Equals("true");
            bool isTransfer = !string.IsNullOrEmpty(Request.Form["isTransfer"]);
            List<Bill> bills = new List<Bill>();
            foreach (int rest in listGroup.Keys)
            {
                int status = statuses[2].Id;
                if (isTransfer)
                {
                    if (!string.IsNullOrEmpty(Request.Form["res_" + rest]))
                    {
                        status = statuses[0].Id;
                    }
                }
                Bill b = ADO.BillADO.Add(new Bill(isTakeAway, isTransfer, status));
                bills.Add(b);
                foreach (Product p in listGroup[rest].Keys)
                {
                    ADO.BillDetailADO.Add(new BillDetail(b.Id, p.Id, listGroup[rest][p], p.Price));
                }
                if (isTakeAway==false)
                {
                    string fullName = Request.Form["fullName"];
                    string phone = Request.Form["phone"];
                    string address = Request.Form["address"];
                    int? id = string.IsNullOrEmpty(Request.Form["id"]) ? null : int.Parse(Request.Form["id"]);
                    ADO.BillTakeAwayADO.Add(new BillTakeAway(b.Id, id, fullName, address, phone));
                }
            }
            string userJson = HttpContext.Session.GetString("user");
            if (userJson == null)
            {
                string get = "";
                if (HttpContext.Session.GetString("RecentBill")!=null)
                {
                    bills.AddRange(JsonConvert.DeserializeObject<List<Bill>>(HttpContext.Session.GetString("RecentBill")));
                }
                get = JsonConvert.SerializeObject(bills);
                HttpContext.Session.SetString("RecentBill", get);
            }
            HttpContext.Session.Remove("cart");
            return RedirectToAction("List");
        }
    }
}
