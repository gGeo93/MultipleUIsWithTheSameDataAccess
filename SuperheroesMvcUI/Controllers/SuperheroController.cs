using Microsoft.AspNetCore.Mvc;
using Repository;
using SuperheroesMvcUI.Models;

namespace SuperheroesMvcUI.Controllers
{
    public class SuperheroController : Controller
    {
        private SuperheroesDisplayServices superheroesDisplayServices;
        private IViewModel viewModel;

        public SuperheroController(SuperheroesDisplayServices supeheroesDisplayServices, IViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.superheroesDisplayServices = supeheroesDisplayServices;
        }

        public async Task<IActionResult> SuperHeroes()
        {
            viewModel.SuperheroesDisplay = await SuperheroesDisplayServices();
            viewModel.SupeheroPageIndex.PageIndex = 0;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SuperHeroes(int modelIndex)
        {
            viewModel.SuperheroesDisplay = await SuperheroesDisplayServices();
            if (modelIndex >= 0 && modelIndex < viewModel.SuperheroesDisplay.Count)
            {
                viewModel.SupeheroPageIndex.PageIndex = modelIndex;
                return View(viewModel);
            }
            viewModel.SupeheroPageIndex.PageIndex = 0;
            return View(viewModel);
        }
        [HttpPost]
        public async Task<ViewResult> EditSuperhero(string heroName) 
        {
            List<ISuperheroDisplayModel> superheroes = await SuperheroesDisplayServices();
            ISuperheroDisplayModel model = superheroes.Find(h => h.HeroName == heroName);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSuperhero(SuperheroDisplayModel singleSuperhero) 
        {
            await superheroesDisplayServices.UpdateDbSuperhero(singleSuperhero);
            return RedirectToAction("SuperHeroes");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSuperhero(string heroName)
        {
            await superheroesDisplayServices.DeleteSuperheroFromDb(heroName);
            await superheroesDisplayServices.SortHeroesByRankAfterDelete();
            return RedirectToAction("SuperHeroes");
        }
        private async Task<List<ISuperheroDisplayModel>> SuperheroesDisplayServices()
        {
            return await superheroesDisplayServices.DbModelsToListOfDisplayModels();
        }
    }
}
