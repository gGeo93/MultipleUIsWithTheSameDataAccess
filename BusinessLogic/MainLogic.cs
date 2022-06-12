using DataAccess;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MainLogic
    {
        public readonly UnitOfWork heroes;
        public MainLogic(SuperheroContext superheroContext)
        {
            heroes = new UnitOfWork(superheroContext);
        }
    }
}
