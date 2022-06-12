namespace SuperheroesWebApi.WebApiData
{
    public interface ISupeheroWebApiModelUse
    {
        string FirstName { get; set; }
        string HeroName { get; set; }
        string LastName { get; set; }
        string Location { get; set; }
        int NumberOfFriends { get; set; }
        int Rank { get; set; }
    }
}