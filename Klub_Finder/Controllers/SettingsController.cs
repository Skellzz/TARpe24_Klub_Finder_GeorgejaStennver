using Klub_Finder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klub_Finder.Controllers
{
    public class SettingsController : Controller
    {

        public IActionResult Index()
        {
            var model = new Settings();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Settings image, string ImageUrl)
        {
            Settings setting = new Settings();
            {
                setting.Id = setting.Id;
                setting.FirstName = setting.FirstName;

                if (!string.IsNullOrEmpty(ImageUrl))
                {
                    setting.Image = ImageUrl;
                }
                else
                {
                    setting.Image = setting.Image;
                }
                setting.Image = null;
                setting.ImagePath = setting.ImagePath;

            }
            ;
            return View(setting);
        }



        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SettingsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

