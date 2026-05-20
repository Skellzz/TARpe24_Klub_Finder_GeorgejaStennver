using Microsoft.AspNetCore.Mvc;

namespace Klub_Finder.Controllers
{
    public class FoodAndDrinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
