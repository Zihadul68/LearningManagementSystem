using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string RegistrationNumber { get; set; } // e.g. "22-47087-1"
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double CGPA { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public Student()
        {
            Enrollments = new List<Enrollment>();
        }
    }
}