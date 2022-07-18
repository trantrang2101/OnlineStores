using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Project.Controllers
{
    public class BillRecentController : Controller
    {

        public IActionResult List()
        {
            dynamic model = new ExpandoObject();
            List<Bill> list = new List<Bill>();
            string userJson = HttpContext.Session.GetString("user");
            if (!string.IsNullOrEmpty(userJson))
            {
                User user = JsonConvert.DeserializeObject<User>(userJson);
                if (user.Permission.Name.ToLower().Equals("shipper"))
                {
                    list = ADO.BillADO.GetListShip(user.Shipper().Id).ToList();
                }else if(user.Permission.Name.ToLower().Equals("waiter")|| user.Permission.Name.ToLower().Equals("owner"))
                {
                    list = ADO.BillADO.GetListRestaurant(user.Id).ToList();
                }
                else
                {
                    return RedirectToAction("List", "Bill");
                }
                model.List = list;
                return View("~/Views/Bill/List.cshtml", model);
            }
            else
            {
                return RedirectToAction("List", "Bill");
            }
        }
    }
}
