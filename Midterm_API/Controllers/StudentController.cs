using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.GetSingleStudent(id);
            return student == null ? NotFound() : Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _studentService.AddStudent(student);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            student = _studentService.GetSingleStudent(id);
            student.Id = id;
            _studentService.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var studentExist = _studentService.GetSingleStudent(id);
            if (studentExist == null)
            {
                return NotFound();
            }
            _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}
