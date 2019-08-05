using Microsoft.AspNetCore.Mvc;
using static checkers_bot.Team;

namespace checkers_bot.Controllers
{
    [Route("api/checkers")]
    [ApiController]
    public class BotCheckerController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult<CheckerMove[]> GetNextMove([FromBody] CheckerPayload payload)
        {
            var startingMoveForWhite = new CheckerMove
            {
                FromPoint = new Point(0, 5),
                ToPoint = new Point(1, 4)
            };
            var startingMoveForBlack = new CheckerMove
            {
                FromPoint = new Point(1, 2),
                ToPoint = new Point(0, 3)
            };

            return new[] {
                payload.Team == White
                    ? startingMoveForWhite
                    : startingMoveForBlack
            };
        }
    }
}
