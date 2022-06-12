using Repository;
using DataAccess;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ConsoleUITest;
using Microsoft.EntityFrameworkCore;

public class Program 
{
    private readonly UnitOfWork heroes;
    public Program(SuperheroContext superheroContext)
    {
        heroes = new UnitOfWork(superheroContext);
    }
    static void Main(string[] args) 
    {
        var serviceCollection = new ServiceCollection();
        
        IConfiguration configuration;
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json")
            .Build();

        serviceCollection.AddDbContext<SuperheroContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("Default")));

        serviceCollection.AddSingleton<Test>();
        serviceCollection.AddScoped<IHeroRepository, SuperheroRepository>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var testInstrance = serviceProvider.GetService<Test>();

        testInstrance.AddHeroViaConsoleApp();
    }
    
}
