using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klub_Finder.Data;
using Klub_Finder.Models;

namespace Klub_Finder.Controllers
{
    public class KlubisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlubisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Klubis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klubid.ToListAsync());
        }

        // GET: Klubis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klubi = await _context.Klubid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klubi == null)
            {
                return NotFound();
            }

            return View(klubi);
        }

        // GET: Klubis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klubis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nimi,Asukoht,Kirjeldus,Pilt,KontaktEmail,Telefon")] Klubi klubi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klubi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klubi);
        }

        // GET: Klubis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klubi = await _context.Klubid.FindAsync(id);
            if (klubi == null)
            {
                return NotFound();
            }
            return View(klubi);
        }

        // POST: Klubis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nimi,Asukoht,Kirjeldus,Pilt,KontaktEmail,Telefon")] Klubi klubi)
        {
            if (id != klubi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klubi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlubiExists(klubi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(klubi);
        }

        // GET: Klubis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klubi = await _context.Klubid
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klubi == null)
            {
                return NotFound();
            }

            return View(klubi);
        }

        // POST: Klubis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klubi = await _context.Klubid.FindAsync(id);
            if (klubi != null)
            {
                _context.Klubid.Remove(klubi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlubiExists(int id)
        {
            return _context.Klubid.Any(e => e.Id == id);
        }
    }
}
