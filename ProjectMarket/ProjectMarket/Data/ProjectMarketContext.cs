using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Models;

namespace ProjectMarket.Models
{
    public class ProjectMarketContext : DbContext
    {
        public ProjectMarketContext(DbContextOptions<ProjectMarketContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Makes the user name uniqe
            modelBuilder.Entity<User>(entity => entity.HasIndex(u => u.UserName).IsUnique());
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, EMail = "admin@gmail.com", FirstName = "AdminF", LastName = "AdminL", IsAdmin = true, UserName = "Admin", Password = "12345678" },
                new User() { Id = 2, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "User", Password = "12345678" }
                );
            modelBuilder.Entity<AcademicInstitute>().HasData(
                new AcademicInstitute() { Id = 1, Name = "המכללה למנהל" },
                new AcademicInstitute() { Id = 2, Name = "מכון לב" }
                );
            modelBuilder.Entity<FieldOfStudy>().HasData(
                new FieldOfStudy() { Id = 1, Name = "מדעי המחשב" },
                new FieldOfStudy() { Id = 2, Name = "כלכלה" },
                new FieldOfStudy() { Id = 3, Name = "פיזיקה" }
            );
        }

        public DbSet<ProjectMarket.Models.AcademicInstitute> AcademicInstitute { get; set; }

        public DbSet<ProjectMarket.Models.FieldOfStudy> FieldOfStudy { get; set; }

        public DbSet<ProjectMarket.Models.User> User { get; set; }

        public DbSet<ProjectMarket.Models.Project> Project { get; set; }

        public DbSet<ProjectMarket.Models.Sale> Sale { get; set; }

        public DbSet<ProjectMarket.Models.Meeting> Meeting { get; set; }
    }
}
