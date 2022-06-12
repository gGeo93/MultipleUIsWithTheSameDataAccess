using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository;
using SuperheroesWebApi.ContextToWebApiModel;
using SuperheroesWebApi.WebApiData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SuperheroContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ISuperHeroRepository, SuperheroRepository>();
builder.Services.AddScoped<ISupeheroWebApiModelUse, SuperheroWebApiModelUse>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
