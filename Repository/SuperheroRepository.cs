using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SuperheroRepository : Repository<Superhero>, ISuperHeroRepository
    {
        public SuperheroRepository(SuperheroContext context) : base(context)
        {
        }

        public async Task<Superhero> GetSuperheroByRank(int rank)
        {
            return await context.Set<Superhero>().FirstOrDefaultAsync(r => r.Rank == rank);
        }
        public async Task<IEnumerable<Superhero>> GetTheMostPopularHeroes(int number)
        {
            return await context.Set<Superhero>().OrderByDescending(s => s.NumberOfFriends).Take(number).ToListAsync();
        }

        public async Task<IEnumerable<Superhero>> GetTheStrongestHeroes(int number)
        {
            return await context.Set<Superhero>().OrderByDescending(s => s.Rank).Take(number).ToListAsync();
        }

        public void SetTheStrongestHeroesByRank() 
        {
            int rank = 1;
            var dbSuperheroes = context.Set<Superhero>();
            foreach (var hero in dbSuperheroes)
            {
                hero.Rank = rank;
                rank += 1;
            }
        }

        public SuperheroContext SuperheroContext => context as SuperheroContext;
        
    }
}
