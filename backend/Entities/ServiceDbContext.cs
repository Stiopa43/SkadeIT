using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<ProjectPhoto> ServicesPhotos { get; set; }
        public DbSet<ProjectTechnology> ServiceTechnologies { get; set; }
        public DbSet<Favor> Favors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntityRules(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ConfigureEntityRules(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasMany(e => e.Technologies)
                .WithMany(e => e.Projects)
                .UsingEntity<ProjectTechnology>();
            modelBuilder.Entity<Project>()
                   .HasMany(e => e.ProjectPhotos)
                   .WithOne(e => e.Project)
                   .HasForeignKey(e=>e.ProjectId);
        }
    }
}
