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
        public async Task<IActionResult> Index()
        {
            var Jook = await _context.Jook.ToListAsync();
            return View(Jook);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jook jook)
        {
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

            return View(jook);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var jook = await _context.Jook.FindAsync(id);

            if (jook == null)
            {
                return NotFound();
            }

            return View(jook);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Jook jook)
        {
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

            return View(jook);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var jook = await _context.Jook
                .FirstOrDefaultAsync(x => x.Id == id);

            if (jook == null)
            {
                return NotFound();
            }

            return View(jook);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
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
