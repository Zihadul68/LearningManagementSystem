using DAL.EF;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        private readonly LMSContext db;

      
        public StudentRepo(LMSContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool Create(Student s)
        {
            db.Students.Add(s);
            return db.SaveChanges() > 0;
        }

        public List<object> Dashboard(int id)
        {
            var student = db.Students.Find(id);
            if (student == null) return new List<object>();

            var enrollments = db.Enrollments.Where(e => e.StudentId == id).ToList();
            var courses = db.Courses.ToList();
            List<Course> enrolledcourses = new List<Course>();

            foreach (Enrollment e in enrollments)
            {
                foreach (Course c in courses)
                {
                    if (e.CourseId == c.Id)
                    {
                        enrolledcourses.Add(c);
                    }
                }
            }
            var result = new List<object>
            {

                new Dictionary<string, object>
                {
                    { "StudentId", student.StudentId },
                   // { "RegistrationNumber", student.RegistrationNumber },
                    { "Name", student.Name },
                    { "Email", student.Email },
                    { "PhoneNumber", student.PhoneNumber },
                    { "CGPA", student.CGPA }
                },

                new Dictionary<string, object>
                {
                    { "Enrollment", enrollments
                        .Select(e =>
                        {
                            
                            var course = db.Courses.Find(e.CourseId);
                            return new Dictionary<string, object>
                            {
                                {"Enrollment ID", e.EnrollId },
                                { "Enrollment Date", e.EnrollmentDate },
                                { "Progress", e.Progress },
                                { "Course ID", e.CourseId },
                                { "Course Name", course?.CourseName ?? "Unknown" },
                                { "Course Instructor", course?.InstructorName ?? "Unknown" },
                                { "Course Duration", course?.Duration ?? "Unknown" }
                            };
                        })
                        .ToList()
                    }
                },
            };

            return result;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            if (ex == null) return false;
            db.Students.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Get()
        {
            return db.Students.ToList();
        }

        public List<Student> SearchByName(string name)
        {
            return db.Students.Where(s => s.Name.Contains(name)).ToList();
        }

        public List<Enrollment> SeeEnrollments(int id)
        {
            return db.Enrollments.Where(e => e.StudentId == id).ToList();
        }

        public bool Update(Student s)
        {
            var ex = Get(s.StudentId);
            if (ex == null) return false;
            db.Entry(ex).CurrentValues.SetValues(s);
            return db.SaveChanges() > 0;
        }
    }
}

