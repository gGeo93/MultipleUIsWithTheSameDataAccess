namespace SuperheroesMvcUI.Models
{
    public interface ISuperheroDisplayModel
    {
        string FirstName { get; set; }
        string HeroImage { get; set; }
        string HeroName { get; set; }
        string LastName { get; set; }
        string Location { get; set; }
        int NumberOfFriends { get; set; }
        int Rank { get; set; }
    }
}