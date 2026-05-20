using Microsoft.AspNetCore.Mvc;

namespace Klub_Finder.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
