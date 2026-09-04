using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.Get(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost("create")]
        public IActionResult Create(BLL.DTOs.StudentDTO student)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var created = _service.Create(student);
            return created ? Ok(created) : BadRequest("Could not create student.");
        }

        [HttpPut("update")]
        public IActionResult Update(BLL.DTOs.StudentDTO student)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var updated = _service.Update(student);
            return updated ? Ok(updated) : NotFound();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            return deleted ? Ok(deleted) : NotFound();
        }

        [HttpGet("seeEnrollments/{id}")]
        public IActionResult SeeEnrollments(int id)
        {
            return Ok(_service.SeeEnrollment(id));
        }

        [HttpGet("dashboard/{id}")]
        public IActionResult Dashboard(int id)
        {
            var data = _service.Dashboard(id);
            if (data.Count == 0) return NotFound();
            return Ok(data);
        }

        [HttpGet("searchByName")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("name is required");

            var data = _service.SearchByName(name);
            if (!data.Any()) return NotFound();

            return Ok(data);
        }
    }
}
