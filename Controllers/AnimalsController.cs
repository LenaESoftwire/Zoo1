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
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var animals = _animals.GetAnimalsList()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize);
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
        public ActionResult<SpeciesListViewModel> SpeciesList([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var species = _animals.GetSpeciesList()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize);
            return new SpeciesListViewModel(species);
        }
    }

}
