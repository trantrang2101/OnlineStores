using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
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
            if(userJson != null)
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
            if (cartStr != null)
            {
                Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
            }
            else
            {
                return RedirectToAction("List");
            }
            Dictionary<Product, int> list = new Dictionary<Product, int>();
            foreach (int key in Cart.Keys)
            {
                list.Add(ADO.ProductADO.GetProduct(key, true), Cart[key]);
            }
            var listGroup = list.GroupBy(x => x.Key.RestaurantId).ToDictionary(x => x.Key, y => y.ToDictionary(x => x.Key, y => y.Value));
            bool isTakeAway = false;
            try
            {
                isTakeAway = !string.IsNullOrEmpty(Request.Form["isTakeAway"]);
            }
            catch 
            {

            }
            bool isTransfer = false;
            try
            {
                isTransfer = !string.IsNullOrEmpty(Request.Form["isTransfer"]);
            }
            catch 
            {

            }
            List<Bill> bills = new List<Bill>();
            List<BillStatus> statuses = ADO.BillStatusADO.GetList(true);
            foreach (int rest in listGroup.Keys)
            {
                int status = statuses[2].Id;
                if (isTransfer)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(Request.Form["res_" + rest]))
                        {
                            status = statuses[0].Id;
                        }
                    }
                    catch
                    {
                    }
                }
                Bill b = ADO.BillADO.Add(new Bill(isTakeAway, isTransfer, status));
                bills.Add(b);
                if (!isTakeAway)
                {
                    string fullName = Request.Form["fullName"].ToString();
                    string phone = Request.Form["phone"].ToString();
                    string address = Request.Form["address"].ToString();
                    int? id = string.IsNullOrEmpty(Request.Form["id"]) ? null : int.Parse(Request.Form["id"]);
                    ADO.BillTakeAwayADO.Add(new BillTakeAway(b.Id, id, fullName, address, phone));
                }
                foreach (Product p in listGroup[rest].Keys)
                {
                    ADO.BillDetailADO.Add(new BillDetail(b.Id, p.Id, listGroup[rest][p], p.Price));
                }
            }
            string userJson = HttpContext.Session.GetString("user");
            if (userJson == null)
            {
                HttpContext.Session.SetString("RecentBill", JsonConvert.SerializeObject(bills));
                HttpContext.Session.SetString("Cart", null);
            }
            return View();
        }
    }
}
