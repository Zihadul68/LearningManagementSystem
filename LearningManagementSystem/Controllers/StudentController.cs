using BLL.Services;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            var data = _service.Get();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.Get(id);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create(BLL.DTOs.StudentDTO s)
        {
            var data = _service.Create(s);
            return Ok(data);
        }
        [HttpPut("update")]
        public IActionResult Update(BLL.DTOs.StudentDTO s)
        {
            var data = _service.Update(s);
            return Ok(data);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = _service.Delete(id);
            return Ok(data);
        }
        [HttpGet("seeEnrollments/{id}")]
        public IActionResult SeeEnrollments(int id)
        {
            var data = _service.SeeEnrollment(id);
            return Ok(data);
        }
        [HttpGet("dashboard/{id}")]
        public IActionResult Dashboard(int id)
        {
            var data = _service.Dashboard(id);
            return Ok(data);
        }
        public static void ExportStudentsToPdf(string filepath)
        {
            var repo = DataAccessFactory.StudentFeatures();
            repo.ExportStudentsToPdf(filepath);
        }
        [HttpGet("searchByName")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("name is required");

            var data = _service.SearchByName(name);
            if (data == null || !data.Any())
                return NotFound();

            return Ok(data);
        }


    }
}
