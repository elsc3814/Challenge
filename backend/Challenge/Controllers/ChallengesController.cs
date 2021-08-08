using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models;
using Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("challenges")]
    public class ChallengesController : ControllerBase
    {
        private readonly IChallengesService _challengeService;

        public ChallengesController(IChallengesService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet]
        public async Task<IEnumerable<ChallengeDB.Models.Challenge>> GetAllChallenges()
        {
            return await _challengeService.GetAllChallenges();
        }

        [HttpGet]
        [Route("{challengeId}/top3")]
        public Task<TopResults> GetTopResults(int challengeId)
        {
            return _challengeService.GetTop3ByChallengeId(challengeId);
        }

        [HttpPost]
        [Route("submitTask")]
        public async Task<ActionResult<JDoodleResponse>> SubmitTask([FromBody] ChallengeEntry challengeEntry)
        {
            try
            {
                var result = await _challengeService.ExecuteAndValidateChallenge(challengeEntry);
                return new OkObjectResult(result);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new {message = e.Message});
            }
        }
    }
}