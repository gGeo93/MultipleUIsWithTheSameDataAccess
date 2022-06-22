using System.ComponentModel.DataAnnotations;

namespace SuperheroesMvcUI.Models
{
    public class SuperheroDisplayModel : ISuperheroDisplayModel
    {
        [MinLength(3)]
        [Required]
        public string HeroName { get; set; } = string.Empty;
        public string HeroImage { get; set; } = string.Empty;
        [MinLength(3)]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [MinLength(3)]
        [Required]
        public string LastName { get; set; } = string.Empty;
        [MinLength(3)]
        [Required]
        public string Location { get; set; } = string.Empty;
        [Range(1, 50, ErrorMessage = "We don't about ranking above 50")]
        [Required]
        public int Rank { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int NumberOfFriends { get; set; }
    }
}
