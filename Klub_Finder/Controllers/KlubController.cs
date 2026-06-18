using Klub_Finder.Data;
using Klub_Finder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klub_Finder.Controllers
{
    public class KlubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlubController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var klub = await _context.Klubid.ToListAsync();
            return View(klub);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Klubi klub)
        {
            if (klub.ImageFile != null)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/klubs");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName =
                    Guid.NewGuid() +
                    Path.GetExtension(klub.ImageFile.FileName);

                string filePath =
                    Path.Combine(folder, fileName);

                using (var stream =
                    new FileStream(filePath, FileMode.Create))
                {
                    await klub.ImageFile.CopyToAsync(stream);
                }

                klub.ImagePath =
                    "/images/klubs/" + fileName;
            }

            _context.Klubid.Add(klub);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var klub = await _context.Klubid.FindAsync(id);

            if (klub == null)
                return NotFound();

            return View(klub);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Klubi klub)
        {
            if (id != klub.Id)
                return NotFound();

            var oldKlub = await _context.Klubid
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (oldKlub == null)
                return NotFound();

            if (klub.ImageFile != null)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/klubs");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName =
                    Guid.NewGuid() +
                    Path.GetExtension(klub.ImageFile.FileName);

                string filePath =
                    Path.Combine(folder, fileName);

                using (var stream =
                    new FileStream(filePath, FileMode.Create))
                {
                    await klub.ImageFile.CopyToAsync(stream);
                }

                klub.ImagePath =
                    "/images/klubs/" + fileName;
            }
            else
            {
                klub.ImagePath = oldKlub.ImagePath;
            }

            _context.Klubid.Update(klub);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var klub = await _context.Klubid.FindAsync(id);

            if (klub == null)
                return NotFound();

            return View(klub);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klub = await _context.Klubid.FindAsync(id);

            if (klub != null)
            {
                _context.Klubid.Remove(klub);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
