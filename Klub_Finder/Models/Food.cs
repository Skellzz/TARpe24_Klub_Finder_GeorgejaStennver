using System.ComponentModel.DataAnnotations.Schema;

namespace Klub_Finder.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string FoodName { get; set;}
        public string Description { get; set; }

        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public DateTime RegisteerimisKuupäev { get; set; } = DateTime.Now;

    }
}
