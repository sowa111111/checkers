using checkers_bot.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace checkers_bot.Controllers
{
    [Route("api/checkers")]
    [ApiController]
    public class BotCheckerController : ControllerBase
    {
        private SearchEnginee _searchEnginee;

        public BotCheckerController()
        {
            _searchEnginee = new SearchEnginee();
        }
        // POST api/values
        [HttpPost]
        public ActionResult<CheckerMove[]> GetNextMove([FromBody] CheckerPayload payload)
        {
            var primaryMove = _searchEnginee.FindNextMove(payload.Field, payload.Team);

            return primaryMove.Any()
                ? (ActionResult<CheckerMove[]>)primaryMove
                : Ok("I don't have an option");
        }
    }
}
