using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SuperheroContext : DbContext
    {

        public SuperheroContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Superhero> Superheroes { get; set; }

    }
}
