

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Midterm_API.Entities;
using Midterm_API.Services;

namespace Midterm_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetAllStudents());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _studentService.CreateStudent(student);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            student.Id = id;
            _studentService.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.RemoveStudent(id);
            return Ok();
        }
    }
}



