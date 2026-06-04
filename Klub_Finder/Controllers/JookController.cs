using Klub_Finder.Data;
using Klub_Finder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klub_Finder.Controllers
{
    public class JookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JookController(ApplicationDbContext context)
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
<<<<<<< HEAD
            var joogid = await _context.Jook.ToListAsync();

            if (await IsAdmin())
            {
                return View("~/Views/FoodAndDrinks/Jook/Index.cshtml", joogid);
            }

            return View("~/Views/UserMenuDrinkFood/Jook/Index.cshtml", joogid);
=======
            var jook = await _context.Jook.ToListAsync();
            return View("~/Views/FoodAndDrinks/Jook/Index.cshtml", jook);
>>>>>>> 8adf4a614757fef99e8e3ba1e6830dfa14cd8b54
        }

        public async Task<IActionResult> Create()
        {
<<<<<<< HEAD
            if (!await IsAdmin())
            {
                return Forbid();
            }
=======
            return View("~/Views/FoodAndDrinks/Jook/Create.cshtml");
        }
>>>>>>> 8adf4a614757fef99e8e3ba1e6830dfa14cd8b54

            return View("~/Views/FoodAndDrinks/Jook/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jook jook)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }

            if (jook.ImageFile != null)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(jook.ImageFile.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await jook.ImageFile.CopyToAsync(stream);
                }

                jook.ImagePath = "/images/" + fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Jook.Add(jook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/FoodAndDrinks/Jook/Create.cshtml", jook);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }

            var jook = await _context.Jook.FindAsync(id);

            if (jook == null)
            {
                return NotFound();
            }

            return View("~/Views/FoodAndDrinks/Jook/Edit.cshtml", jook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Jook jook)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }

            if (id != jook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(jook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("~/Views/FoodAndDrinks/Jook/Edit.cshtml", jook);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }

            var jook = await _context.Jook
                .FirstOrDefaultAsync(x => x.Id == id);

            if (jook == null)
            {
                return NotFound();
            }

            return View("~/Views/FoodAndDrinks/Jook/Delete.cshtml", jook);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await IsAdmin())
            {
                return Forbid();
            }

            var jook = await _context.Jook.FindAsync(id);

            if (jook != null)
            {
                _context.Jook.Remove(jook);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}