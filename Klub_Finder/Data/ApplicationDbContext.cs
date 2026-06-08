using Klub_Finder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Dynamic;
namespace Klub_Finder.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Klubi> Klubid { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Jook> Jook { get; set; }
    }
}
