using EFCoreSession03.Enums;
using EFCoreSession03.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession03.Configrations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Description).IsRequired(false).HasMaxLength(1000);
            builder.Property(c => c.Level).IsRequired();
            builder.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.IsPublished).IsRequired();
            builder.Property(c => c.PublishededAt).IsRequired(false);
            // Relations 
            builder.HasOne<Instructor>().WithMany()
                   .HasForeignKey(c => c.InstructorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(c => c.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
            // Seed Data
            builder.HasData(
                    new Course
                    {
                        Id = 1,
                        Title = "C# Fundamentals",
                        Description = "Learn C# basics",
                        Price = 500,
                        Level = CourseLevel.Beginner,
                        IsPublished = true,
                        PublishededAt = new DateTime(2024, 2, 1),
                        InstructorId = 1,
                        CategoryId = 1
                    },
                new Course
                {
                    Id = 2,
                    Title = "ASP.NET Core Web API",
                    Description = "Build Web APIs using ASP.NET Core",
                    Price = 1200,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishededAt = new DateTime(2024, 3, 1),
                    InstructorId = 1,
                    CategoryId = 4
                },
                new Course
                {
                    Id = 3,
                    Title = "HTML and CSS",
                    Description = "Learn frontend basics",
                    Price = 400,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishededAt = new DateTime(2024, 4, 1),
                    InstructorId = 2,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 4,
                    Title = "Advanced JavaScript",
                    Description = "Advanced JavaScript concepts",
                    Price = 900,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishededAt = null,
                    InstructorId = 2,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 5,
                    Title = "Software Engineering",
                    Description = "Software engineering principles",
                    Price = 750,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishededAt = new DateTime(2024, 5, 1),
                    InstructorId = 3,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 6,
                    Title = "Advanced Backend Development",
                    Description = "Advanced backend concepts",
                    Price = 1500,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishededAt = null,
                    InstructorId = 3,
                    CategoryId = 2
                }
            );


        }
    }
}
