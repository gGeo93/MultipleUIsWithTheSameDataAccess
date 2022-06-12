using DataAccess.Data;
using SuperheroesWebApi.WebApiData;

namespace SuperheroesWebApi.WebApiModelToContext
{
    public class DisplayToDbDataConverter
    {
        public List<Superhero> DisplayToDbSuperheroes(List<SuperheroWebApiModelUse> displaySuperheroes)
        {
            List<Superhero> dbSupehero = new List<Superhero>();

            foreach (var hero in displaySuperheroes)
            {
                dbSupehero.Add(new Superhero
                {
                    Rank = hero.Rank,
                    HeroName = hero.HeroName,
                    FirstName = hero.FirstName,
                    LastName = hero.LastName,
                    NumberOfFriends = hero.NumberOfFriends,
                    Location = hero.Location
                });
            }
            return dbSupehero;
        }
        public Superhero DisplayToDbSuperhero(SuperheroWebApiModelUse displaySuperhero)
        {
            Superhero dbSuperhero = new Superhero();

            dbSuperhero.Rank = displaySuperhero.Rank;
            dbSuperhero.HeroName = displaySuperhero.HeroName;
            dbSuperhero.FirstName = displaySuperhero.FirstName;
            dbSuperhero.LastName = displaySuperhero.LastName;
            dbSuperhero.NumberOfFriends = displaySuperhero.NumberOfFriends;
            dbSuperhero.Location = displaySuperhero.Location;

            return dbSuperhero;
        }
    }
}
