// See https://aka.ms/new-console-template for more information
using ConsoleAppUITest;
using DataAccess;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;


var serviceCollection = new ServiceCollection();

serviceCollection.AddTransient<Test>();
serviceCollection.AddTransient<SuperheroContext>();
serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();


IConfiguration configuration;

configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
    .AddJsonFile("app_settings.json")
    .Build();

serviceCollection.AddDbContext<SuperheroContext>(option =>
     option.UseSqlServer(configuration.GetConnectionString("Default")));



var serviceProvider = serviceCollection.BuildServiceProvider();
var testInstance = serviceProvider.GetRequiredService<Test>();
await testInstance.AddHeroViaConsole();
   
    