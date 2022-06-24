using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository;
using SuperheroesMvcUI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SuperheroContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ISuperheroDisplayModel, SuperheroDisplayModel>();
builder.Services.AddTransient<IPageIndex, PageIndexDisplay>();
builder.Services.AddTransient<IViewModel, ViewModel>();
builder.Services.AddTransient<SuperheroesDisplayServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
