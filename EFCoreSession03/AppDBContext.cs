using EFCoreSession03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession03
{
    public class AppDBContext :DbContext
    {
        public AppDBContext() 
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS01;Database=OnlineLearningPlatformDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
            }
            
        }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDBContext).Assembly
                );
        }

    }
}
