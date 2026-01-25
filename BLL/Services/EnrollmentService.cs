using AutoMapper;
using BLL.DTOs;
using DAL.EF.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repos;

namespace BLL.Services
{
public class EnrollmentService
    {
        EnrollmentRepo repo;
        public EnrollmentService(EnrollmentRepo repo) {
            this.repo = repo;
        }
        public List<EnrollmentDTO> Get()
        {
            var data = repo.Get();
            var Mapper=MapperConfig.GetMapper();
            var ret=Mapper.Map<List<EnrollmentDTO>>(data);
            return ret;

        }
        public EnrollmentDTO Get(int id)
        {
            var data = repo.Get(id);
            var Mapper = MapperConfig.GetMapper();
            var ret = Mapper.Map<EnrollmentDTO>(data);
            return ret;
        }
        public bool Create(EnrollmentDTO e)
        {
            var Mapper = MapperConfig.GetMapper();
            var data = Mapper.Map<Enrollment>(e);
            return repo.Create(data);
        }
        public bool update(EnrollmentDTO e)
        {
            var Mapper = MapperConfig.GetMapper();
            var data = Mapper.Map<Enrollment>(e);
            return repo.Create(data);
        }
        public bool Delete(int id)
        {
            
            {
             
                return repo.Delete(id);
            }
          
            
        }

    }
}
