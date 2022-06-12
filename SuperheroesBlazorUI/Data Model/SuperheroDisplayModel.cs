using System.ComponentModel.DataAnnotations;

namespace SuperheroesBlazorUI.Data_Model
{
    public class SuperheroDisplayModel
    {        
        [MaxLength(30)]
        [Required]
        public string HeroName { get; set; }
        
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(20)]
        [Required]
        public string Location { get; set; }
        [Range(1,50)]
        [Required]
        public int Rank { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int NumberOfFriends { get; set; }
    }
}
