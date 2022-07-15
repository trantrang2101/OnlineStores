using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Project.Controllers
{
    public class RestaurantController : Controller
    {

        public RestaurantController()
        {
        }
        public IActionResult Detail(int id, int cateId, int page)
        {
            dynamic model = new ExpandoObject();
            bool? status = true;
            Restaurant restaurant = ADO.RestaurantADO.GetRestaurant(id, true);
            ICollection<Product> products = restaurant.Products(true);
            if (cateId != 0)
            {
                Category cate = ADO.CategoryADO.GetCategory(cateId, true);
                products = cate.GetProducts(true);
                model.Category = cate;
            }
            string json = HttpContext.Session.GetString("user");
            if (json != null)
            {
                User user = JsonConvert.DeserializeObject<User>(json);
                if (user.Permission.Features.Where(x => x.Id == 6).Count() > 2)
                {
                    status = null;
                }
            }
            model.Page = page;
            model.Restaurant = restaurant;
            model.Categories = ADO.CategoryADO.GetList(id, status);
            model.Count = products.Count();
            model.List = products.Skip(page * 16).Take(16).ToList();
            return View(model);
        }
        public IActionResult List(int page)
        {
            bool? status = true;
            string view = "List";
            string json = HttpContext.Session.GetString("user");
            if (json != null)
            {
                User user = JsonConvert.DeserializeObject<User>(json);
                if (user.Permission.Features.Where(x => x.Id == 6).Count() > 2)
                {
                    status = null;
                    view = "Table";
                }
            }
            List<Restaurant> restaurants = ADO.RestaurantADO.GetList(status);
            dynamic model = new ExpandoObject();
            model.Page = page;
            model.Count = restaurants.Count();
            model.List = restaurants.Skip(page * 16).Take(16);
            return View(view, model);
        }
    }
}
