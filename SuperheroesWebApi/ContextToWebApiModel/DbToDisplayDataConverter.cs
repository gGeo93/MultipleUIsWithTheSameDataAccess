using DataAccess.Data;
using SuperheroesWebApi.WebApiData;

namespace SuperheroesWebApi.ContextToWebApiModel
{
    public class DbToDisplayDataConverter
    {
        public List<SuperheroWebApiModelUse> DbSuperheroesToDisplaySuperheroes(List<Superhero> dbSuperheroes) 
        {
            List<SuperheroWebApiModelUse> superheroWebApisUseList = new List<SuperheroWebApiModelUse>();
            
            foreach (var hero in dbSuperheroes)
            {
                superheroWebApisUseList.Add(new SuperheroWebApiModelUse
                {
                    Rank = hero.Rank,
                    HeroName = hero.HeroName,
                    FirstName = hero.FirstName,
                    LastName = hero.LastName,
                    NumberOfFriends = hero.NumberOfFriends,
                    Location = hero.Location
                });
            }
            return superheroWebApisUseList;
        }
        public SuperheroWebApiModelUse DbSuperheroToDisplaySuperhero(Superhero dbSuperhero) 
        { 
            SuperheroWebApiModelUse supeheroWebApilUse = new SuperheroWebApiModelUse();
            
            supeheroWebApilUse.Rank = dbSuperhero.Rank;
            supeheroWebApilUse.HeroName = dbSuperhero.HeroName;
            supeheroWebApilUse.FirstName = dbSuperhero.FirstName;
            supeheroWebApilUse.LastName = dbSuperhero.LastName;
            supeheroWebApilUse.NumberOfFriends = dbSuperhero.NumberOfFriends;
            supeheroWebApilUse.Location = dbSuperhero.Location;

            return supeheroWebApilUse;
        }
    }
}
