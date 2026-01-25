using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CourseRepo : IRepo<Course, int, Course>, ICourseFeatures
    {
        LMSContext db;

        public CourseRepo()
        {
        }

        public CourseRepo(LMSContext db)
        {
            this.db = db;
        }
        public bool Create(Course c)
        {
            db.Courses.Add(c);
            return db.SaveChanges() > 0;

        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Courses.Remove(ex);
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

        public bool Update(Course c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
           
        }

        Course IRepo<Course, int, Course>.Create(Course obj)
        {
            throw new NotImplementedException();
        }

        Course IRepo<Course, int, Course>.Update(Course obj)
        {
            throw new NotImplementedException();
        }
    }

    internal interface ICourseFeatures
    {
    }
}

