using BLL.DTOs;
using DAL.EF.Model;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        CourseRepo repo;
        public CourseService(CourseRepo repo)
        {
            this.repo = repo;
        }
        public List<CourseDTO> Get() {
         var data = repo.Get();
            var Mapper =MapperConfig.GetMapper();
            var ret = Mapper.Map<List<CourseDTO>>(data);
            return ret;
        }
        public CourseDTO Get(int id)
        {
            var data = repo.Get(id);
            var Mapper = MapperConfig.GetMapper();
            var ret = Mapper.Map<CourseDTO>(data);
            return ret;
        }
        public bool Create(CourseDTO c)
        {
            var Mapper = MapperConfig.GetMapper();
            var data=Mapper.Map<Course>(c);
            return repo.Create(data);
        }
        public bool Update(CourseDTO c)
        {
            var Mapper = MapperConfig.GetMapper();
            var data = Mapper.Map<Course>(c);
            return repo.Update(data);
        }
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

       
        public List<CourseDTO> GetCoursesSortedByDuration()
        {
            var data = repo.GetCoursesSortedByDuration();
            var Mapper = MapperConfig.GetMapper();
            return Mapper.Map<List<CourseDTO>>(data);
        }
    }
}
