using DataAccess;
using DataAccess.Data;
using Repository;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SuperheroesMvcUI.Models
{
    public class SuperheroesDisplayServices
    {
        private IUnitOfWork unitOfWork;
        
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
        public async Task AddSuperheroToDb(SuperheroDisplayModel herotoToBeAdded)
        {
            Superhero newSuperhero = new Superhero {
                ImgFileName = herotoToBeAdded.HeroImage,
                HeroName = herotoToBeAdded.HeroName,
                FirstName = herotoToBeAdded.FirstName,
                LastName = herotoToBeAdded.LastName,
                Location = herotoToBeAdded.Location,
                NumberOfFriends = herotoToBeAdded.NumberOfFriends,
                Rank = herotoToBeAdded.Rank
            };
            await unitOfWork.SuperHeroes.Add(newSuperhero);
            await SaveDbChanges();
        }
        public async Task UpdateDbSuperhero(SuperheroDisplayModel model) 
        {
            List<Superhero> dbSuperhero = (List<Superhero>) await unitOfWork.SuperHeroes.Find(h => h.HeroName == model.HeroName);
            if (dbSuperhero != null) 
            {
                dbSuperhero[0].HeroName = model.HeroName;
                dbSuperhero[0].FirstName = model.FirstName;
                dbSuperhero[0].LastName = model.LastName;
                dbSuperhero[0].Location = model.Location;
                dbSuperhero[0].NumberOfFriends = model.NumberOfFriends;
                dbSuperhero[0].Rank = model.Rank;
                await unitOfWork.Complete();
            }
        }
        public async Task DeleteSuperheroFromDb(string heroName) 
        {
            var superheroToDelete = (List<Superhero>)await unitOfWork.SuperHeroes.Find(h => h.HeroName == heroName);
            unitOfWork.SuperHeroes.Remove(superheroToDelete[0]);
            await SaveDbChanges();
        }
        public async Task SortHeroesByRankAfterDelete() 
        {
            unitOfWork.SuperHeroes.SetTheStrongestHeroesByRank();
            await SaveDbChanges();
        }
        private async Task SaveDbChanges() 
        {
            await unitOfWork.Complete();
        }
    }
}
