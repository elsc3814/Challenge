using System.Collections.Generic;
using System.Threading.Tasks;
using ChallengeDB.Models;

namespace ChallengeDB
{
    public interface IChallengeStore
    {
        Task<IList<Challenge>> GetAllChallenges();
        Task<Challenge> GetChallengeById(int id);
        Task SaveChallengeResult(Challenge challenge, string script, string name, int memory, float cpuTime);

        Task<IList<ChallengeResult>> GetTopResultsByMemory(int challengeId);
        Task<IList<ChallengeResult>> GetTopResultsByCpuTime(int challengeId);
    }
}