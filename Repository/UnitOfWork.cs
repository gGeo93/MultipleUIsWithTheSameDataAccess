using DataAccess;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperheroContext context;
        public UnitOfWork(SuperheroContext context)
        {
            this.context = context;
            SuperHeroes = new SuperheroRepository(this.context);
        }
        public ISuperHeroRepository SuperHeroes { get; private set; }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
