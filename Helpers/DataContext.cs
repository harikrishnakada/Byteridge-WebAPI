using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Entities;
using WebApi.Entities.CodeList;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role() { Id = 1, DisplayName = "Auditor", InternalIdentifier = RoleCode.Values.Auditor, LandingPageUrl = "/audit", CreatedDateTime =DateTime.Now, LastChangedDateTime = DateTime.Now },
                 new Role() { Id = 2, DisplayName = "User", InternalIdentifier = RoleCode.Values.User, LandingPageUrl = "/", CreatedDateTime = DateTime.Now, LastChangedDateTime = DateTime.Now });
        }
    }
}