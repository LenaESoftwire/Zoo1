using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Linq;
using zoo.Repositories;
using zoo.Request;
using Zoo.Filters;

namespace zoo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeepersController : ControllerBase
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly IKeepersRepo _keepers;

        public KeepersController(IKeepersRepo keepers)
        {
            _keepers = keepers;
        }

        [HttpGet("/keepers/{id}")]
        public ActionResult<KeeperViewModel> KeeperById([FromRoute] int id)
        {
            var keeper = new KeeperViewModel();
            try
            {
                keeper = _keepers.GetKeeperById(id);
            }
            catch
            {
                Logger.Error($"There is no animal with Id: {id} in our zoo");
                return new NotFoundResult();
            }

            Logger.Info($"Getting an animal with {id} id");
            return keeper;
        }

        //[HttpPost("/animals/create")]
        //public IActionResult AddAnimal(AddAnimalViewModel addAnimalViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        Logger.Error($"Add animal request is not valid");
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        _keepers.AddAnimal(addAnimalViewModel);
        //        return RedirectToAction("AnimalsList");
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

    }
}
