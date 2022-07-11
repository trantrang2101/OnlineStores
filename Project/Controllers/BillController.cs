using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class BillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
