using DAL.EF.Model;
using DAL.Interfaces;
using DAL.Repos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Student, int, Student> StudentData { get; }

        public static IRepo<Course, int, Course> CourseData()
        {
            return new CourseRepo();
        }

        public static IRepo<Enrollment, int, Enrollment> EnrollmentData()
        {
            EnrollmentRepo enrollmentRepo = new();
            return (IRepo<Enrollment, int, Enrollment>)enrollmentRepo;
        }

        public static IEnrollmentFeatures EnrollmentFeatures()
        {
            EnrollmentRepo enrollmentRepo = new();
            return (IEnrollmentFeatures)enrollmentRepo;
        }

        public static IStudentFeatures StudentFeatures()
        {
            return new StudentRepos();
        }

        public static Interfaces.ICourseFeatures CourseFeatures
        {
            get
            {
                CourseRepo courseRepo = new();
                return (Interfaces.ICourseFeatures)courseRepo;
            }
        }
    }

    internal class StudentRepos : IStudentFeatures
    {
        public List<object> Dashoard(int id)
        {
            throw new NotImplementedException();
        }

        public void ExportStudentsToPdf(string filePath)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Enrollment> SeeEnrollments(int id)
        {
            throw new NotImplementedException();
        }
    }
}
