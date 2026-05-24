using Klub_Finder.Data;
using Klub_Finder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klub_Finder.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var food = await _context.Food.ToListAsync();
            return View("~/Views/FoodAndDrinks/Food/Index.cshtml", food);
        }

        public IActionResult Create()
        {
            return View("~/Views/FoodAndDrinks/Food/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Food food)
        {
            if (food.ImageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(food.ImageFile.FileName);
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