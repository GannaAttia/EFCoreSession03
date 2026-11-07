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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired(false).HasMaxLength(500);
            //self-ref relationship
            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            #region Seed Data
            builder.HasData(
                new Category {
                    Id = 1,
                    Name = "Programming",
                    Description = "Programming courses",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Backend",
                    Description = "Backend development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Frontend",
                    Description = "Frontend development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 4,
                    Name = "ASP.NET",
                    Description = "ASP.NET development",
                    ParentCategoryId = 2
                },
                new Category
                {
                    Id = 5,
                    Name = "Web Design",
                    Description = "Web design courses",
                    ParentCategoryId = 3
                }
                );
            #endregion
        }
    }
}
