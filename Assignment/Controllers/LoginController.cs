using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Assignment.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Authenticate()
        {
            string mail = Request.Form["email"];
            string password  = Request.Form["password"];
            HRManagementContext context = new HRManagementContext();
            Employee employee = context.Employees.Where(x => BCrypt.Net.BCrypt.Verify(x.Password, password) && x.Email.ToLower().Equals(x.Email.ToLower()));
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
