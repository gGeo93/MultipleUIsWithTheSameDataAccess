using DataAccess.Data;

namespace Repository
{
    public interface ISuperHeroRepository : IRepository<Superhero>
    {
        Task<Superhero> GetSuperheroByRank(int rank);
        Task<IEnumerable<Superhero>> GetTheStrongestHeroes(int number);
        Task<IEnumerable<Superhero>> GetTheMostPopularHeroes(int number);
    }
}
