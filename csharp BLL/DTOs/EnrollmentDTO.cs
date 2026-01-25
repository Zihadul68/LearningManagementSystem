using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EnrollmentDTO
    {
        public int EnrollId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Progress { get; set; } = string.Empty;

        public int StudentId { get; set; }
        public int CourseId { get; set; }

      
    }
}