using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable("Student");
            modelBuilder.Entity<Student>()
                .Property(s => s.Age)
                .IsRequired(false);
            //modelBuilder.Entity<Student>()
            //    .Property(s => s.IsRegularStudent)
            //    .HasDefaultValue(true);

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student
                    {
                        StudentId = Guid.NewGuid(),
                        Name = "John Doe",
                        Age = 30
                    },
                    new Student
                    {
                        StudentId = Guid.NewGuid(),
                        Name = "Jane Doe",
                        Age = 25
                    }
                );
        }

        public DbSet<Student> Students { get; set; }
    }
}
