using DataAccess;
using DataAccess.Data;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUITest
{
    public class Test
    {
        private readonly UnitOfWork heroes;
        public Test(SuperheroContext superheroContext)
        {
            heroes = new UnitOfWork(superheroContext);
        }
        public async Task AddHeroViaConsoleApp() 
        {
            Superhero hero = new Superhero() {Id = 6, HeroName = "Froppy", FirstName = "Tsuyu", LastName = "Asui", Location = "Japan", Rank = 6, NumberOfFriends = 9 };
            await heroes.SuperHeroes.Add(hero);
            await heroes.Complete();
        }
    }
}
