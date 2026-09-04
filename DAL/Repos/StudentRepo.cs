using DAL.EF;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class StudentRepo
    {
        private readonly LMSContext db;

        public StudentRepo(LMSContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool Create(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges() > 0;
        }

        public List<object> Dashboard(int id)
        {
            var student = db.Students.Find(id);
            if (student == null) return new List<object>();

            var enrollments = db.Enrollments.Where(e => e.StudentId == id).ToList();
            var courses = db.Courses.ToList();

            var result = new List<object>
            {
                new Dictionary<string, object>
                {
                    { "StudentId", student.StudentId },
                    { "Name", student.Name },
                    { "Email", student.Email },
                    { "PhoneNumber", student.PhoneNumber },
                    { "CGPA", student.CGPA }
                },
                new Dictionary<string, object>
                {
                    { "Enrollment", enrollments.Select(enrollment =>
                        {
                            var course = courses.FirstOrDefault(c => c.Id == enrollment.CourseId);
                            return new Dictionary<string, object>
                            {
                                { "Enrollment ID", enrollment.EnrollId },
                                { "Enrollment Date", enrollment.EnrollmentDate },
                                { "Progress", enrollment.Progress },
                                { "Course ID", enrollment.CourseId },
                                { "Course Name", course?.CourseName ?? "Unknown" },
                                { "Course Instructor", course?.InstructorName ?? "Unknown" },
                                { "Course Duration", course?.Duration ?? "Unknown" }
                            };
                        }).ToList()
                    }
                }
            };

            return result;
        }

        public bool Delete(int id)
        {
            var existing = Get(id);
            if (existing == null) return false;

            db.Students.Remove(existing);
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
            return db.Students
                .Where(s => s.Name.Contains(name))
                .ToList();
        }

        public List<Enrollment> SeeEnrollments(int id)
        {
            return db.Enrollments
                .Where(e => e.StudentId == id)
                .ToList();
        }

        public bool Update(Student student)
        {
            var existing = Get(student.StudentId);
            if (existing == null) return false;

            db.Entry(existing).CurrentValues.SetValues(student);
            return db.SaveChanges() > 0;
        }
    }
}
