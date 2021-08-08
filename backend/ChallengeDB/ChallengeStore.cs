using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDB
{
    public class ChallengeStore : IChallengeStore
    {
        private readonly ChallengeContext _context;

        public ChallengeStore(ChallengeContext context)
        {
            _context = context;
        }

        public async Task<IList<Challenge>> GetAllChallenges()
        {
            return await _context.Challenges.AsNoTracking().ToListAsync();
        }

        public Task<Challenge> GetChallengeById(int id)
        {
            return _context.Challenges.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<ChallengeResult>> GetTopResultsByMemory(int challengeId)
        {
            return await _context.ChallengeResults.AsNoTracking()
                .Where(x => x.ChallengeId == challengeId)
                .OrderBy(x => x.Memory)
                .Take(3)
                .ToListAsync();
        }

        public async Task<IList<ChallengeResult>> GetTopResultsByCpuTime(int challengeId)
        {
            return await _context.ChallengeResults.AsNoTracking()
                .Where(x => x.ChallengeId == challengeId)
                .OrderBy(x => x.CpuTime)
                .Take(3)
                .ToListAsync();
        }

        public async Task SaveChallengeResult(Challenge challenge, string script, string name, int memory, float cpuTime)
        {
            await using (_context)
            {
                _context.ChallengeResults.Add(new ChallengeResult()
                {
                    ChallengeId = challenge.Id,
                    Script = script,
                    Name = name,
                    Memory = memory,
                    CpuTime = cpuTime
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}