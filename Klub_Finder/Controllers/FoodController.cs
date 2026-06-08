using Klub_Finder.Data;
using Klub_Finder.Migrations;
using Klub_Finder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Klub_Finder.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> IsAdmin()
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.UserName == User.Identity.Name);

            return user != null && user.IsAdmin == true;
        }


        public async Task<IActionResult> Index()
        {
            var foods = await _context.Food.ToListAsync();
            if (await IsAdmin())
            {
                return View("~/Views/FoodAndDrinks/Food/Index.cshtml", foods);
            }

            return View("~/Views/UserMenuDrinkFood/Food/Index.cshtml", foods);

        }

        public async Task<IActionResult> Create()
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }
            return View("~/Views/FoodAndDrinks/Food/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Food food)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }
            
            ModelState.Remove("ImageFile");
            ModelState.Remove("ImagePath");
          
            if (food.ImageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                   

                string fileName = Guid.NewGuid().ToString()
                                  + Path.GetExtension(food.ImageFile.FileName);
                
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await food.ImageFile.CopyToAsync(stream);
                }

                food.ImagePath = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                
                _context.Food.Add(food);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/FoodAndDrinks/Food/Create.cshtml", food);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }

            var food = await _context.Food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return View("~/Views/FoodAndDrinks/Food/Edit.cshtml", food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Food food)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/FoodAndDrinks/Food/Edit.cshtml", food);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }
            var food = await _context.Food
                .FirstOrDefaultAsync(x => x.Id == id);

            if (food == null)
            {
                return NotFound();
            }

            return View("~/Views/FoodAndDrinks/Food/Delete.cshtml", food);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }
            var food = await _context.Food.FindAsync(id);

            if (food != null)
            {
                _context.Food.Remove(food);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}