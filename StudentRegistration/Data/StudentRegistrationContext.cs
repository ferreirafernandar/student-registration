using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StudentRegistration.Data.Config;
using StudentRegistration.Data.Mapping;
using StudentRegistration.Models;
using System;
using System.IO;
using System.Linq;

namespace StudentRegistration.Data
{
    public class StudentRegistrationContext : DbContext
    {
        public StudentRegistrationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentConfig());
            builder.ApplyConfiguration(new PhoneConfig());
  
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry =>
                entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreationDate").CurrentValue = DateTime.Now;
                else if (entry.State == EntityState.Modified)
                    entry.Property("CreationDate").IsModified = false;
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry =>
                entry.Entity.GetType().GetProperty("ModificationDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("ModificationDate").CurrentValue = null;
                else if (entry.State == EntityState.Modified)
                    entry.Property("ModificationDate").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<StudentRegistrationContext>
        {
            StudentRegistrationContext IDesignTimeDbContextFactory<StudentRegistrationContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<StudentRegistrationContext>();
                optionsBuilder.UseSqlServer<StudentRegistrationContext>("Data Source=DESKTOP-NFF4QND;Database=StudentRegistration;user id=sa;password=yakuza0800212121;");

                return new StudentRegistrationContext(optionsBuilder.Options);
            }
        }
    }
}