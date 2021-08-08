using System.ComponentModel.DataAnnotations;

namespace ChallengeDB.Models
{
    public class Challenge
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Input { get; set; }

        public string Output { get; set; }
    }
}