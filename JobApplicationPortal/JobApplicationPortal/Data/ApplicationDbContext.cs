using JobApplicationPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace JobApplicationPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<JobApplicationPortal>()
                .HasIndex(ja => new { ja.UserId, ja.JobPostingId })
                .IsUnique();
            builder.Entity<JobPosting>()
                .HasOne(jp => jp.Recruiter)
                .WithMany()
                .HasForeignKey(jp => jp.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}