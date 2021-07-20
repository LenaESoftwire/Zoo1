using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult<AnimalListViewModel> AnimalsList()
        {
            var animals = _animals.GetAnimalsList();
            return new AnimalListViewModel(animals);
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalViewModel> AnimalById([FromRoute] int id)
        {
            
            //_logger.LogInformation($"Found an animal with {id}. It is a {anim");
            return _animals.GetAnimalById(id);
        }
    }

}
