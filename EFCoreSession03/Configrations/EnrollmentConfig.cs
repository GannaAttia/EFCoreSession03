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
    internal class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
    {

        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.StudentId, e.CourseId });
            builder.Property(e => e.EnrollmentDate).IsRequired();
            builder.Property(e => e.Progress).HasPrecision(5, 2).IsRequired();
            builder.Property(e => e.Status).IsRequired();
            builder.Property(e => e.FinalGarde)
                   .HasPrecision(5, 2)
                   .IsRequired(false);
            builder.HasOne<Student>()
                   .WithMany()
                   .HasForeignKey(e => e.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Course>()
                   .WithMany()
                   .HasForeignKey(e => e.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
