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

        [HttpPost("/keepers/create")]
        public IActionResult AddKeeper(AddKeeperViewModel addKeeperViewModel)
        {
            if (!ModelState.IsValid)
            {
                Logger.Error($"Add keeper request is not valid");
                return BadRequest(ModelState);
            }
            try
            {
                var newKeeper = _keepers.AddKeeper(addKeeperViewModel);
                return RedirectToAction("KeeperById", new { id = newKeeper.Id });
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
