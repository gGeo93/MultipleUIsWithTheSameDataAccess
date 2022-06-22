using System.ComponentModel.DataAnnotations;
namespace DataAccess.Data
{
    public class Superhero
    {
        [Key]
        public int Id { get; set; }
        public string HeroName { get; set; } = string.Empty;
        public string ImgFileName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Rank { get; set; }
        public int NumberOfFriends { get; set; }
    }
}
