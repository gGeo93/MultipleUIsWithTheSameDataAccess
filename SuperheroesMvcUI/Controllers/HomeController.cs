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
        private IViewModel viewModel;

        public HomeController(ILogger<HomeController> logger, SuperheroesDisplayServices supeheroesDisplayServices, IViewModel viewModel)
        {
            _logger = logger;
            this.viewModel = viewModel;
            this.superheroesDisplayServices = supeheroesDisplayServices;
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
            viewModel.SuperheroesDisplay = await SuperheroesDisplayServices();
            viewModel.SupeheroroPageIndex.PageIndex = 0;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SuperHeroes(int modelIndex) 
        {
            viewModel.SuperheroesDisplay = await SuperheroesDisplayServices();
            if (modelIndex>=0 && modelIndex<=8)
            {
                viewModel.SupeheroroPageIndex.PageIndex = modelIndex;
                return View(viewModel);
            }
            viewModel.SupeheroroPageIndex.PageIndex = 0;
            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<List<ISuperheroDisplayModel>> SuperheroesDisplayServices() 
        {
            return await superheroesDisplayServices.DbModelsToListOfDisplayModels();
        }
    }
}