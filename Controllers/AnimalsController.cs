using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using zoo.Repositories;
using zoo.Request;
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
            try
            {
                var animals = _animals.SearchAnimals(filter);
                return animals.Any() ? new AnimalListViewModel(animals) : new NotFoundResult();
            }
            catch
            {
                Logger.Error($"There is no such animal in our zoo");
                return NotFound();
            }
        }

        [HttpGet("/animals/{id}")]
        public ActionResult<AnimalViewModel> AnimalById([FromRoute] int id)
        {
            var animal = new AnimalViewModel();
            try
            {
                animal = _animals.GetAnimalById(id);
            }
            catch
            {
                Logger.Error($"There is no animal with Id: {id} in our zoo");
                return NotFound();
            }

            Logger.Info($"Getting an animal with {id} id");
            return animal;
        }

        [HttpPost("/animals/create")]
        public IActionResult AddAnimal(AddAnimalViewModel addAnimalViewModel)
        {
            try
            {
                _animals.AddAnimal(addAnimalViewModel);
                return RedirectToAction("AnimalsList");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
