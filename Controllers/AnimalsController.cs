using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AnimalsController> _logger;
        private readonly IAnimalsRepo _animals;

        public AnimalsController(ILogger<AnimalsController> logger, IAnimalsRepo animals)
        {
            _logger = logger;
            _animals = animals;
        }

        [HttpGet("/animals")]
        public ActionResult<AnimalListViewModel> AnimalsList([FromQuery] PaginationFilter filter)
        {
            var animals = _animals.GetAnimalsList()
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);
            return new AnimalListViewModel(animals);
        }

        [HttpGet("/search")]
        public ActionResult<AnimalListViewModel> SearchAnimals ( [FromQuery] PaginationFilter pageFilter)
        {
            var animals = _animals.GetAnimalsList(pageFilter);
                
            return new AnimalListViewModel(animals);
        }

        //[HttpGet("/animals/?pageNumber=1&pageSize=10")]


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
        public ActionResult<SpeciesListViewModel> SpeciesList([FromQuery] PaginationFilter pageFilter)
        {
            var species = _animals.GetSpeciesList(pageFilter);
            return new SpeciesListViewModel(species);
        }
    }

}
