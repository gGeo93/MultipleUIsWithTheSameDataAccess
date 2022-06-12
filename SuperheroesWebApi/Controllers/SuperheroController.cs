using DataAccess;
using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using SuperheroesWebApi.ContextToWebApiModel;
using SuperheroesWebApi.WebApiData;
using SuperheroesWebApi.WebApiModelToContext;
using System.Collections;

namespace SuperheroesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : ControllerBase
    {
        private readonly IUnitOfWork heroes;
        private DbToDisplayDataConverter dbToDisplayData;
        private DisplayToDbDataConverter displayToDbData;

        public SuperheroController(SuperheroContext superheroContext)
        {
            heroes = new UnitOfWork(superheroContext);
            dbToDisplayData = new DbToDisplayDataConverter();
            displayToDbData = new DisplayToDbDataConverter();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allHeroes = (List<Superhero>)await heroes.SuperHeroes.GetAll();
            var allHeroesToDisplay = dbToDisplayData.DbSuperheroesToDisplaySuperheroes(allHeroes);
            if (allHeroesToDisplay is null || allHeroesToDisplay.Count == 0)
            {
                return NotFound("Something went wrong with the transormation of data");
            }
            return Ok(allHeroesToDisplay);
        }

        [HttpGet("{rank}")]
        public async Task<IActionResult> GetHero(int rank)
        {
            var hero = await heroes.SuperHeroes.GetSuperheroByRank(rank);
            var displaHeroByRank = dbToDisplayData.DbSuperheroToDisplaySuperhero(hero);
            if (displaHeroByRank is null) 
            {
                return BadRequest("There is no hero with this rank.");
            }
            return Ok(displaHeroByRank);
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperheroWebApiModelUse superherodisplay)
        {
            Superhero dbSuperhero = displayToDbData.DisplayToDbSuperhero(superherodisplay);
            await heroes.SuperHeroes.Add(dbSuperhero);
            await heroes.Complete();
            return Ok();
        }
        [Route("AddHeroes")]
        [HttpPost]
        public async Task<IActionResult> AddHeroes(List<SuperheroWebApiModelUse> displaysuperheroes)
        {
            List<Superhero> dbSuperheroes = displayToDbData.DisplayToDbSuperheroes(displaysuperheroes);
            await heroes.SuperHeroes.AddRange(dbSuperheroes);
            await heroes.Complete();
            return Ok();
        }
        [Route("UpdateHero")]
        [HttpPut]
        public async Task<ActionResult<IEnumerable<Superhero>>> UpdateHero(SuperheroWebApiModelUse request)
        {
            List<Superhero> chosenHero = (List<Superhero>)await heroes.SuperHeroes.Find(super => super.Rank == request.Rank);
            if (chosenHero == null)
            {
                return BadRequest("There is no such hero with this Id");
            }
            chosenHero[0].HeroName = request.HeroName;
            chosenHero[0].FirstName = request.FirstName;
            chosenHero[0].LastName = request.LastName;
            chosenHero[0].Location = request.Location;
            chosenHero[0].NumberOfFriends = request.NumberOfFriends;
            chosenHero[0].Rank = request.Rank;
            await heroes.Complete();
            return Ok(chosenHero);
        }
        [HttpDelete("{rank}")]
        public async Task<IActionResult> DeleteHero(int rank)
        {
            List<Superhero> heroDeleted = (List<Superhero>)await heroes.SuperHeroes.Find(super => super.Rank == rank);
            if (heroDeleted == null)
                return BadRequest("No hero to delete");
            heroes.SuperHeroes.Remove(heroDeleted[0]);
            await heroes.Complete();
            return Ok();
        }
    }
}
