using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeDB.Models
{
    public class ChallengeResult
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Script { get; set; }

        [ForeignKey("ChallengeId")] public Challenge Challenge { get; set; }

        public int ChallengeId { get; set; }

        public int Memory { get; set; }

        public float CpuTime { get; set; }
    }
}