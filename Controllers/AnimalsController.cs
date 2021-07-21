using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Linq;
using zoo.Repositories;
using zoo.Response;
using Zoo.Filters;

namespace zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        [HttpGet("/animals")]
        public ActionResult<AnimalListViewModel> AnimalsList([FromQuery] SearchFilter filter)
        {
            filter.Validation();
            var animals = _animals.GetAnimalsList(filter);
         
            return new AnimalListViewModel(animals);
        }

        [HttpGet("/search")]
        public ActionResult<AnimalListViewModel> SearchAnimals([FromQuery] AnimalsSearchRequest filter)
        {
            filter.Validation();
            var animals = _animals.SearchAnimals(filter);

            return new AnimalListViewModel(animals);
        }

        [HttpGet("/animals/{id}")]
        public ActionResult<AnimalViewModel> AnimalById([FromRoute] int id)
            {
            Logger.Info($"Found an animal with {id} id");
            return _animals.GetAnimalById(id);
            }

        [HttpPost("/animals/create")]
        public IActionResult AddAnimal(AddAnimalViewModel addAnimalViewModel)
        {
            _animals.AddAnimal(addAnimalViewModel);
            return RedirectToAction("AnimalsList");
        }

        [HttpGet("/species")]
        public ActionResult<SpeciesListViewModel> SpeciesList([FromQuery] SearchFilter pageFilter)
        {
            pageFilter.Validation();
            var species = _animals.GetSpeciesList(pageFilter);
            return new SpeciesListViewModel(species);
        }
    }

}
