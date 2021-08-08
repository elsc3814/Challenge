using System.Collections.Generic;
using ChallengeDB.Models;

namespace Challenge.Models
{
    public class TopResults
    {
        public IList<ChallengeResult> ByMemory { get; set; }
        public IList<ChallengeResult> ByCpuTime { get; set; }
    }
}