using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Project.Controllers
{
    public class CartController : Controller
    {
        Dictionary<int, int> Cart { get; set; }
        public CartController()
        {
        }

        public IActionResult Update(int id)
        {
            if (Cart == null)
            {
                string cartStr = HttpContext.Session.GetString("cart");
                if (cartStr != null)
                {
                    Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
                }
                else
                {
                    Cart = new Dictionary<int, int>();
                }
            }
            if (Cart != null && Cart.ContainsKey(id))
            {
                
                if (Request.Form["quantity"].Equals("0"))
                {
                    Cart.Remove(id);
                }
                else
                {
                    int quantity = int.Parse(Request.Form["quantity"]);
                    Cart[id] = quantity;
                }
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(Cart));
            return RedirectToAction("List");
        }

        public IActionResult Remove(int id)
        {
            if (Cart == null)
            {
                string cartStr = HttpContext.Session.GetString("cart");
                if (cartStr != null)
                {
                    Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
                }
                else
                {
                    Cart = new Dictionary<int, int>();
                }
            }
            if (Cart != null && Cart.ContainsKey(id))
            {
                Cart.Remove(id);
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(Cart));
            return RedirectToAction("List");
        }

        public IActionResult Add(int id)
        {
            if (Cart == null)
            {
                string cartStr = HttpContext.Session.GetString("cart");
                if (cartStr != null)
                {
                    Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
                }
                else
                {
                    Cart = new Dictionary<int, int>();
                }
            }
            Product p = ADO.ProductADO.GetProduct(id,true);
            if (p != null)
            {
                if (Cart != null && !Cart.ContainsKey(id))
                {
                    Cart.Add(id, 1);
                }
                else
                {
                    Cart[id] += 1;
                }
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(Cart));
            return Redirect("/Restaurant/Detail/" + p.Restaurant.Id + "/" + p.CategoryId);
        }

        public IActionResult CheckOut()
        {
            if (Cart == null)
            {
                string cartStr = HttpContext.Session.GetString("cart");
                if (cartStr != null)
                {
                    Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
                }
                else
                {
                    return RedirectToAction("List");
                }
            }
            dynamic model = new ExpandoObject();
            Dictionary<Product, int> list = new Dictionary<Product, int>();
            foreach (int key in Cart.Keys)
            {
                list.Add(ADO.ProductADO.GetProduct(key, true), Cart[key]);
            }
            var listGroup = list.GroupBy(x => x.Key.RestaurantId).ToDictionary(x => x.Key, y => y.ToDictionary(x => x.Key, y => y.Value));
            model.Cart = listGroup;
            return View(model);
        }

        public IActionResult List()
        {
            if (Cart == null)
            {
                string cartStr = HttpContext.Session.GetString("cart");
                if (cartStr != null)
                {
                    Cart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartStr);
                }
                else
                {
                    Cart = new Dictionary<int, int>();
                }
            }
            dynamic model = new ExpandoObject();
            Dictionary<Product, int> list = new Dictionary<Product, int>();
            foreach (int key in Cart.Keys)
            {
                list.Add(ADO.ProductADO.GetProduct(key, true), Cart[key]);
            }
            model.Cart = list.GroupBy(x => x.Key.RestaurantId).ToDictionary(x => x.Key, y => y.ToDictionary(x => x.Key, y => y.Value));
            return View(model);
        }
    }
}
