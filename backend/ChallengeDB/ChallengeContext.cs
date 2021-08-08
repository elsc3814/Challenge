using ChallengeDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDB
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options)
        {
        }

        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<ChallengeResult> ChallengeResults { get; set; }
    }
}