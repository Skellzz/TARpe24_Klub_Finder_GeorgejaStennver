using System.ComponentModel.DataAnnotations;
namespace Klub_Finder.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Rember me ?")]
        public bool RemeberMe { get; set; }
    }
}
