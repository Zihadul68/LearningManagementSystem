using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        EnrollmentService service;
        public EnrollmentController(EnrollmentService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            {
                var data = service.Get();
                return Ok(data);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(BLL.DTOs.EnrollmentDTO e)
        {
            var data = service.Create(e);
            return Ok(data);
        }
        [HttpPut("update")]
        public IActionResult Update(BLL.DTOs.EnrollmentDTO e)
        {
            var data = service.update(e);
            return Ok(data);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            return Ok(data);
        }
        //[HttpGet("courses-with-enrolled-students")]

        //public async Task<IActionResult> GetCoursesWithEnrolledStudents()
        //{
        //    var data = await service.GetCoursesWithEnrolledStudentsAsync(); // implement async service
        //    if (data == null || !data.Any()) return NoContent();
        //    return Ok(data);
        //}
    }
}
