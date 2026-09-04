using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EnrollmentService
    {
        private readonly EnrollmentRepo repo;

        public EnrollmentService(EnrollmentRepo repo)
        {
            this.repo = repo;
        }

        public List<EnrollmentDTO> Get()
        {
            var data = repo.Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<EnrollmentDTO>>(data);
        }

        public EnrollmentDTO Get(int id)
        {
            var data = repo.Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<EnrollmentDTO>(data);
        }

        public bool Create(EnrollmentDTO e)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Enrollment>(e);
            return repo.Create(data);
        }

        public bool Update(EnrollmentDTO e)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Enrollment>(e);
            return repo.Update(data) != null;
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
