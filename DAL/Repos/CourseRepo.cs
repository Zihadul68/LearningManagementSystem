using DAL.EF;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class CourseRepo
    {
        private readonly LMSContext db;

        public CourseRepo(LMSContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool Create(Course course)
        {
            db.Courses.Add(course);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var existing = Get(id);
            if (existing == null) return false;

            db.Courses.Remove(existing);
            return db.SaveChanges() > 0;
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }

        public List<Course> GetCoursesSortedByDuration()
        {
            return db.Courses.OrderByDescending(c => c.Duration).ToList();
        }

        public bool Update(Course course)
        {
            var existing = Get(course.Id);
            if (existing == null) return false;

            db.Entry(existing).CurrentValues.SetValues(course);
            return db.SaveChanges() > 0;
        }
    }
}
