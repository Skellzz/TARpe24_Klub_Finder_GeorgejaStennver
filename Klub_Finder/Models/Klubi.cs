using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Klub_Finder.Models
{
    public class Klubi
    {
        public int Id { get; set; }

        [Required]
        public string ClubName { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string City { get; set; }
        public int DistanceKm { get; set; }
        public bool Is18Plus { get; set; }
        public bool HasLiveMusic { get; set; }
        public string MusicType { get; set; }
    }
}
