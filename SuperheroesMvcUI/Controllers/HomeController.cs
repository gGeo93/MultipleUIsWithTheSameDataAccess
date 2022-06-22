using Microsoft.AspNetCore.Mvc;
using Repository;
using SuperheroesMvcUI.Models;
using System.Diagnostics;

namespace SuperheroesMvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SuperheroesDisplayServices superheroesDisplayServices;
        private IPageIndex pageIndex;

        public HomeController(ILogger<HomeController> logger, SuperheroesDisplayServices supeheroesDisplayServices, IPageIndex pageIndex)
        {
            _logger = logger;
            this.superheroesDisplayServices = supeheroesDisplayServices;
            this.pageIndex = pageIndex;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> SuperHeroes() 
        {
            List<ISuperheroDisplayModel> superheroDisplayModels = await superheroesDisplayServices.DbModelsToListOfDisplayModels();
            ViewBag.Superheroes = superheroDisplayModels;
            pageIndex.PageIndex = 0;
            return View(pageIndex);
        }
        [HttpPost]
        public async Task<IActionResult> SuperHeroes(PageIndexDisplay model) 
        {
            List<ISuperheroDisplayModel> superheroDisplayModels = await superheroesDisplayServices.DbModelsToListOfDisplayModels();
            ViewBag.Superheroes = superheroDisplayModels;
            pageIndex.PageIndex = model.PageIndex;
            return View(pageIndex);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}