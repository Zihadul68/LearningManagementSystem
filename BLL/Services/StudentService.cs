using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using DAL.Repos;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;
        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }
        public List<StudentDTO> Get()
        {
            var data = repo.Get();
            var Mapper = MapperConfig.GetMapper();
            var ret = Mapper.Map<List<StudentDTO>>(data);
            return ret;
        }
        public StudentDTO Get(int id)
        {
            var data = repo.Get(id);
            var Mapper = MapperConfig.GetMapper();
            var ret = Mapper.Map<StudentDTO>(data);
            return ret;
        }
        public bool Create(StudentDTO s)
        {
            var Mapper = MapperConfig.GetMapper();
            var data = Mapper.Map<Student>(s);
            return repo.Create(data);
        }


        public bool Update(StudentDTO s)
        {
            var Mapper = MapperConfig.GetMapper();
            var data = Mapper.Map<Student>(s);
            return repo.Update(data);

        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
        public List<EnrollmentDTO> SeeEnrollment(int id)
        {

            var data = repo.SeeEnrollments(id);
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<EnrollmentDTO>>(data);
            return ret;
        }
        public List<object> Dashboard(int id)
        {
            return repo.Dashboard(id);
        }

        public static void ExportStudentsToPdf(string filepath)
        {
            var repo = DataAccessFactory.StudentFeatures();
            repo.ExportStudentsToPdf(filepath);
        }

        public List<StudentDTO> SearchByName(string name)
        {
            var results = repo.SearchByName(name);
            var mapper = MapperConfig.GetMapper();
            if (results == null) return new List<StudentDTO>();
            return mapper.Map<List<StudentDTO>>(results);
        }


    }
}