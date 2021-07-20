using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using zoo.Repositories;
using zoo.Response;

namespace zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly ILogger<AnimalsController> _logger;
        private readonly IAnimalsRepo _animals;

        public AnimalsController(ILogger<AnimalsController> logger, IAnimalsRepo animals)
        {
            _logger = logger;
            _animals = animals;
        }

        [HttpGet("/animals")]
        public ActionResult<AnimalListViewModel> AnimalsList()
        {
            var animals = _animals.GetAnimalsList();
            return new AnimalListViewModel(animals);
        }

        [HttpGet("/animals/{id}")]
        public ActionResult<AnimalViewModel> AnimalById([FromRoute] int id) =>

            //_logger.LogInformation($"Found an animal with {id}. It is a {anim");
            _animals.GetAnimalById(id);

        [HttpPost("/animals/create")]
        public IActionResult AddAnimal(AddAnimalViewModel addAnimalViewModel)
        {
            _animals.AddAnimal(addAnimalViewModel);
            return RedirectToAction("AnimalsList");
        }

        [HttpGet("/species")]
        public ActionResult<SpeciesListViewModel> SpeciesList()
        {
            var species = _animals.GetSpeciesList();
            return new SpeciesListViewModel(species);
        }
    }

}
