using DAL.EF;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class EnrollmentRepo
    {
        private readonly LMSContext db;

        public EnrollmentRepo(LMSContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool Create(Enrollment enrollment)
        {
            db.Enrollments.Add(enrollment);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = Get(id);
            if (existing == null) return false;

            db.Enrollments.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public Enrollment Get(int id)
        {
            return db.Enrollments.Find(id);
        }

        public List<Enrollment> Get()
        {
            return db.Enrollments.ToList();
        }

        public List<object> GetCoursesWithEnrolledStudents()
        {
            var courses = db.Courses.ToList();
            var enrollments = db.Enrollments.ToList();
            var students = db.Students.ToList();

            return courses.Select(course => new Dictionary<string, object>
            {
                { "CourseId", course.Id },
                { "CourseName", course.CourseName },
                { "InstructorName", course.InstructorName },
                { "EnrolledStudents", enrollments
                    .Where(e => e.CourseId == course.Id)
                    .Select(e =>
                    {
                        var student = students.FirstOrDefault(s => s.StudentId == e.StudentId);
                        return new Dictionary<string, object>
                        {
                            { "StudentId", e.StudentId },
                            { "Name", student?.Name ?? "Unknown" },
                            { "Email", student?.Email ?? "Unknown" },
                            { "Phone", student?.PhoneNumber ?? "Unknown" },
                            { "CGPA", student == null ? "Unknown" : student.CGPA.ToString("0.00") }
                        };
                    })
                    .ToList()
                }
            }).Cast<object>().ToList();
        }

        public Enrollment Update(Enrollment enrollment)
        {
            var existing = Get(enrollment.EnrollId);
            if (existing == null) return null;

            db.Entry(existing).CurrentValues.SetValues(enrollment);
            return db.SaveChanges() > 0 ? existing : null;
        }
    }
}
