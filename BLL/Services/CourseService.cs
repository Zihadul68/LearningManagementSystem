using BLL.DTOs;
using DAL.EF.Model;
using DAL.Repos;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CourseService
    {
        private readonly CourseRepo repo;

        public CourseService(CourseRepo repo)
        {
            this.repo = repo;
        }

        public List<CourseDTO> Get()
        {
            var data = repo.Get();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<CourseDTO>>(data);
        }

        public CourseDTO Get(int id)
        {
            var data = repo.Get(id);
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<CourseDTO>(data);
        }

        public bool Create(CourseDTO course)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Course>(course);
            return repo.Create(data);
        }

        public bool Update(CourseDTO course)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Course>(course);
            return repo.Update(data);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<CourseDTO> GetCoursesSortedByDuration()
        {
            var data = repo.GetCoursesSortedByDuration();
            var mapper = MapperConfig.GetMapper();
            return mapper.Map<List<CourseDTO>>(data);
        }
    }
}
