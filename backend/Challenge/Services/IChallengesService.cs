using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models;

namespace Challenge.Services
{
    public interface IChallengesService
    {
        Task<IList<ChallengeDB.Models.Challenge>> GetAllChallenges();
        Task<JDoodleResponse> ExecuteAndValidateChallenge(ChallengeEntry challengeEntry);
        Task<TopResults> GetTop3ByChallengeId(int challengeId);
    }
}