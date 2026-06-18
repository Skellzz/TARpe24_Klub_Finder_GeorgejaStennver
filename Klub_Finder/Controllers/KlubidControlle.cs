using Klub_Finder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klub_Finder.Controllers
{
    public class KlubidController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KlubidController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var klubid = await _context.Klubid.ToListAsync();
            return View(klubid);
        }

        [HttpPost]
        public IActionResult Like(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Dislike(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult SuperLike(int id)
        {
            return Ok();
        }
    }
}
