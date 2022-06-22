using DataAccess;
using DataAccess.Data;
using Repository;

namespace SuperheroesMvcUI.Models
{
    public class SuperheroesDisplayServices
    {
        private readonly IUnitOfWork unitOfWork;
        
        public SuperheroesDisplayServices(SuperheroContext superheroContext)
        {
            unitOfWork = new UnitOfWork(superheroContext);
        }

        public async Task<List<ISuperheroDisplayModel>> DbModelsToListOfDisplayModels() 
        {
            List<ISuperheroDisplayModel> superheroesDisplayModels = new();
            IEnumerable<Superhero> dbSuperheroes = await unitOfWork.SuperHeroes.GetAll();
            foreach (var dbHero in dbSuperheroes)
            {
                superheroesDisplayModels.Add(new SuperheroDisplayModel
                {
                    HeroName = dbHero.HeroName,
                    HeroImage = dbHero.ImgFileName,
                    FirstName = dbHero.FirstName,
                    LastName = dbHero.LastName,
                    Location = dbHero.Location,
                    NumberOfFriends = dbHero.NumberOfFriends,
                    Rank = dbHero.Rank
                });
            }
            return superheroesDisplayModels;
        }
    }
}
