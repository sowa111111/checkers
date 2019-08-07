using checkers_bot.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var possibleMoves = _searchEnginee.SearchAllPossibleMoves(payload).ToArray();

            if (possibleMoves?.Any() == true)
            {
                var weightedResult = possibleMoves
                    .GroupBy(x => x.Weight)
                    .OrderByDescending(x => x.Key)
                    .ToArray();

                var maxWeight = weightedResult[0].ToArray();
                var random = new Random();
                return maxWeight[random.Next(maxWeight.Length)].Moves;
            }

            return Ok("I don't have an option");
        }
    }
}
