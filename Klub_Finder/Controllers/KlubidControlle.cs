using Klub_Finder.Data;
using Klub_Finder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Klub_Finder.Controllers
{
    public class KlubidController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public KlubidController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(
            string? city,
            int? maxDistance,
            bool? is18Plus,
            bool? hasLiveMusic,
            string? musicType)
        {
            var klubid = _context.Klubid.AsQueryable();

            if (!string.IsNullOrEmpty(city))
                klubid = klubid.Where(x => x.City.Contains(city));

            if (maxDistance.HasValue)
                klubid = klubid.Where(x => x.DistanceKm <= maxDistance.Value);

            if (is18Plus.HasValue)
                klubid = klubid.Where(x => x.Is18Plus == is18Plus.Value);

            if (hasLiveMusic.HasValue)
                klubid = klubid.Where(x => x.HasLiveMusic == hasLiveMusic.Value);

            if (!string.IsNullOrEmpty(musicType))
                klubid = klubid.Where(x => x.MusicType.Contains(musicType));

            return View(await klubid.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            return await SaveReaction(id, "Like");
        }

        [HttpPost]
        public async Task<IActionResult> Dislike(int id)
        {
            return await SaveReaction(id, "Dislike");
        }

        [HttpPost]
        public async Task<IActionResult> SuperLike(int id)
        {
            return await SaveReaction(id, "SuperLike");
        }

        private async Task<IActionResult> SaveReaction(int klubId, string reactionType)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var oldReaction = await _context.KlubReactions
                .FirstOrDefaultAsync(x => x.UserId == user.Id && x.KlubId == klubId);

            if (oldReaction != null)
            {
                oldReaction.ReactionType = reactionType;
                _context.KlubReactions.Update(oldReaction);
            }
            else
            {
                _context.KlubReactions.Add(new KlubReaction
                {
                    UserId = user.Id,
                    KlubId = klubId,
                    ReactionType = reactionType
                });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}