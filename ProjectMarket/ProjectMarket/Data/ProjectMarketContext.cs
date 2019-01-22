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
            //Stops delete when there is a foreigng key attached to the deleted 
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // Makes the user name uniqe
            modelBuilder.Entity<User>(entity => entity.HasIndex(u => u.UserName).IsUnique());
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, EMail = "admin@gmail.com", FirstName = "AdminF", LastName = "AdminL", IsAdmin = true, UserName = "Admin", Password = "12345678" },
                new User() { Id = 2, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "User", Password = "12345678" },
                new User() { Id = 3, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "Buyer", Password = "12345678" },
                new User() { Id = 4, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "Seller", Password = "12345678" },
                new User() { Id = 5, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "BuyerSeller", Password = "12345678" },
                new User() { Id = 6, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "deleted", Password = "12345678" ,IsDeleted = true},
                new User() { Id = 7, EMail = "user@gmail.com", FirstName = "UserF", LastName = "UserL", IsAdmin = false, UserName = "Grader", Password = "12345678" }
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
            modelBuilder.Entity<Project>().HasData(
                new Project() {Id = 1,Name = "DeletedOfUser" , OwnerId = 2,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=true,Price=10.0},
                new Project() {Id = 2,Name = "DeletedOfDelUser" , OwnerId = 6,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=true,Price=20.0 },
                new Project() {Id = 3,Name = "Sold" , OwnerId = 5,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=false,Price=30.0 },
                new Project() {Id = 4,Name = "NotSold" , OwnerId = 4,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=false,Price=40.0 },
                new Project() {Id = 5,Name = "SoldAndDeleted" , OwnerId = 4,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=true,Price=50.0 },
                new Project() {Id = 6,Name = "SoldMultiple" , OwnerId = 4,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=false,Price=60.0 },
                new Project() {Id = 7,Name = "Graded" , OwnerId = 4,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=false,Price=60.0 },
                new Project() {Id = 8,Name = "NotGraded" , OwnerId = 4,Description="",AcademicInstituteId=1,FieldOfStudyId = 2,IsDeleted=false,Price=60.0 }
                );
            modelBuilder.Entity<Sale>().HasData(
                new Sale() { Id= 1,ProjectId = 3,BuyerId = 1,Price = 0.0,AcademicInstituteId= 1,Rank=null,Grade=null},
                new Sale() { Id= 2,ProjectId = 5,BuyerId = 1,Price = 0.0,AcademicInstituteId= 1,Rank=2,Grade=70},
                new Sale() { Id= 3,ProjectId = 6,BuyerId = 3,Price = 0.0,AcademicInstituteId= 2,Rank=null,Grade=null},
                new Sale() { Id= 4,ProjectId = 6,BuyerId = 5,Price = 0.0,AcademicInstituteId= 2,Rank=3,Grade=70},
                new Sale() { Id= 5,ProjectId = 7,BuyerId = 3,Price = 0.0,AcademicInstituteId= 1,Rank=4,Grade=80},
                new Sale() { Id= 6,ProjectId = 8,BuyerId = 3,Price = 0.0,AcademicInstituteId= 2,Rank=null,Grade=null}
                );

        }

        public DbSet<ProjectMarket.Models.AcademicInstitute> AcademicInstitute { get; set; }

        public DbSet<ProjectMarket.Models.FieldOfStudy> FieldOfStudy { get; set; }

        public DbSet<ProjectMarket.Models.User> User { get; set; }

        public DbSet<ProjectMarket.Models.Project> Project { get; set; }

        public DbSet<ProjectMarket.Models.Sale> Sale { get; set; }

    }
}
