using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUITest
{
    public class Test
    {
        private readonly IUnitOfWork unitOfWork;
        

        public Test(SuperheroContext superheroContext)
        {
            unitOfWork = new UnitOfWork(superheroContext);
        }

        public async Task AddHeroViaConsole()
        {
             Superhero superhero = new Superhero { HeroName = "TestHero", 
                                                   FirstName = "Minoru", 
                                                   LastName = "Mineta", 
                                                   Location = "Japan", 
                                                   NumberOfFriends = 8, 
                                                   Rank = 8 };
            await unitOfWork.SuperHeroes.Add(superhero);
            await unitOfWork.Complete();
           
        }
    }
}
 