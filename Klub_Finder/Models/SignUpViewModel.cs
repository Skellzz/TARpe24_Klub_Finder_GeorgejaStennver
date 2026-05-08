using System.ComponentModel.DataAnnotations;
namespace Klub_Finder.Models
{
    public class SignUpViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public int City { get; set; }
    }
}
