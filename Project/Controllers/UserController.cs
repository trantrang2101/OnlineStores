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
    public class UserController : Controller
    {
        public UserController()
        {
        }
        public IActionResult Logout()
        {
            String user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("List", "Restaurant");
        }
        public IActionResult Login()
        {
            string mail = Request.Form["Username"];
            string password = Request.Form["Password"];
            User user = ADO.UserADO.LoginUser(mail, password);
            if (user != null)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                HttpContext.Session.SetString("features", JsonConvert.SerializeObject(user.Features()));
                return View("~/Views/User/Dashboard.cshtml");
            }
            else
            {
                return RedirectToAction("List", "Restaurant");
            }
        }
        public IActionResult List(int page)
        {
            String user = HttpContext.Session.GetString("user");
            if(user != null)
            {
                User login = JsonConvert.DeserializeObject<User>(user);
                if (login.Permission.Features.First(x => x.Title.ToLower().Equals("user")) != null)
                {
                    dynamic model = new ExpandoObject();
                    model.Page = page;
                    model.List = ADO.UserADO.GetList(null).Skip(page * 15).Take(15).ToList();
                    model.Count = ADO.UserADO.GetList(null).Count();
                    return View(model);
                }
            }
            return RedirectToAction("List", "Restaurant");
        }
    }
}
