using Klub_Finder.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
namespace Klub_Finder.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Klubi> Klubid { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
