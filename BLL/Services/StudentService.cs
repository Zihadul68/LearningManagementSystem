using BLL.DTOs;
using DAL.EF.Model;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class StudentService
    {
        private readonly StudentRepo repo;

        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        public List<StudentDTO> Get()
        {
            var data = repo.Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<StudentDTO>>(data);
        }

        public StudentDTO Get(int id)
        {
            var data = repo.Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<StudentDTO>(data);
        }

        public bool Create(StudentDTO student)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Student>(student);
            return repo.Create(data);
        }

        public bool Update(StudentDTO student)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Student>(student);
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
            return mapper.Map<List<EnrollmentDTO>>(data);
        }

        public List<object> Dashboard(int id)
        {
            return repo.Dashboard(id);
        }

        public List<StudentDTO> SearchByName(string name)
        {
            var results = repo.SearchByName(name);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<StudentDTO>>(results);
        }
    }
}
