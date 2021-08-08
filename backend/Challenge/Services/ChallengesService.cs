using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Challenge.Models;
using ChallengeDB;
using ChallengeDB.Models;

namespace Challenge.Services
{
    public class ChallengesService : IChallengesService
    {
        private readonly IChallengeStore _challengeStore;
        private readonly IJDoodleService _jDoodleService;

        public ChallengesService(IChallengeStore challengeStore, IJDoodleService jDoodleService)
        {
            _challengeStore = challengeStore;
            _jDoodleService = jDoodleService;
        }

        public Task<IList<ChallengeDB.Models.Challenge>> GetAllChallenges()
        {
            return _challengeStore.GetAllChallenges();
        }

        public async Task<JDoodleResponse> ExecuteAndValidateChallenge(ChallengeEntry challengeEntry)
        {
            var challenge = await _challengeStore.GetChallengeById(challengeEntry.ChallengeId);

            if (challenge == default) throw new Exception("Wrong challenge id");

            var result = await _jDoodleService.CompileAndExecuteCode(challengeEntry.Script, challenge.Input);

            if (result.Output != challenge.Output) throw new Exception("Wrong output was generated");

            await _challengeStore.SaveChallengeResult(challenge, challengeEntry.Script, challengeEntry.Name, int.Parse(result.Memory),
                float.Parse(result.CpuTime, CultureInfo.InvariantCulture.NumberFormat));

            return result;
        }

        public async Task<TopResults> GetTop3ByChallengeId(int challengeId)
        {
            return new TopResults()
            {
                ByCpuTime = await _challengeStore.GetTopResultsByCpuTime(challengeId),
                ByMemory = await _challengeStore.GetTopResultsByMemory(challengeId)
            };
        }
    }
}