using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _service;

        public CourseController(CourseService service)
        {
            _service = service;
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

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        public IActionResult Create([FromBody] CourseDTO c)
        {
            if (c == null)
                return BadRequest("Request body is empty or contains invalid JSON.");

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var created = _service.Create(c);

            if (!created)
                return BadRequest("Could not create course.");

            return Ok(created);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CourseDTO c)
        {
            if (c == null)
                return BadRequest("Request body is empty or contains invalid JSON.");

            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var updated = _service.Update(c);

            if (!updated)
                return NotFound("Course not found or could not be updated.");

            return Ok(updated);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok(deleted);
        }

        [HttpGet("sortedByDuration")]
        public IActionResult GetCoursesSortedByDuration()
        {
            var data = _service.GetCoursesSortedByDuration();
            return Ok(data);
        }
    }
}
```
