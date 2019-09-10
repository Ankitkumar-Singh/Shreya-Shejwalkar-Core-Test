using Microsoft.EntityFrameworkCore;

namespace CandidateQualifications.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
    }
}
