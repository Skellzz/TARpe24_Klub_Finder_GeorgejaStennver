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
        //[Display(Name = "Sisesta parool uuesti")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Paroolid ei kattu, kontrolli et samad.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string City { get; set; }
    }
}
