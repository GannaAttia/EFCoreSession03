using EFCoreSession03.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession03.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public decimal Progress { get; set; }
        public decimal? FinalGarde {  get; set; }
        public EnrollmentStatus Status { get; set; }
    }
}
