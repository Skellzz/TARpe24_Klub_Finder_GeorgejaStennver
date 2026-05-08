using Microsoft.AspNetCore.Identity;
namespace Klub_Finder.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string? Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string City  { get; set; }
        public DateTime RegistreerimisKuupaev { get; set; } = DateTime.Now;

    }
}
