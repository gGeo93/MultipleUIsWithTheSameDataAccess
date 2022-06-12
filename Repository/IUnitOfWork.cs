namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ISuperHeroRepository SuperHeroes { get; }
        Task Complete();
    }
}