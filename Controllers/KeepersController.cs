using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using zoo.Repositories;
using zoo.Request;

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
            var keeper = _keepers.GetKeeperById(id);

            if (keeper == null)
            {
                Logger.Error($"There is no keeper with Id: {id} in our zoo");
                return NotFound();
            }

            Logger.Info($"Getting an keeper with {id} id");
            return keeper;
        }

        [HttpPost("/keepers/create")]
        public IActionResult AddKeeper(AddKeeperViewModel addKeeperViewModel)
        {
            try
            {
                var newKeeper = _keepers.AddKeeper(addKeeperViewModel);
                return RedirectToAction("KeeperById", new { id = newKeeper.Id });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
