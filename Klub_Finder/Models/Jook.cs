using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klub_Finder.Models
{
    public class Jook
    {
        public int Id { get; set; }
        public string DrinkName { get; set; }
        public string DrinkType { get; set; }
        public int AlcoholPercentage { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public DateTime RegistreerimsKuupäevn { get; set; } = DateTime.Now;
    }
}
