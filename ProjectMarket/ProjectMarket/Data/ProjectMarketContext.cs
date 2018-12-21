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
        public ProjectMarketContext (DbContextOptions<ProjectMarketContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectMarket.Models.AcademicInstitute> AcademicInstitute { get; set; }

        public DbSet<ProjectMarket.Models.FieldOfStudy> FieldOfStudy { get; set; }

        public DbSet<ProjectMarket.Models.User> User { get; set; }

        public DbSet<ProjectMarket.Models.Project> Project { get; set; }

        public DbSet<ProjectMarket.Models.Sale> Sale { get; set; }
    }
}
