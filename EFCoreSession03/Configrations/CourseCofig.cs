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



        }
    }
}
