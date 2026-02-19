using Microsoft.AspNetCore.Mvc;
using Midterm_API.Entities;
using Midterm_API.Services;

namespace Midterm_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        // get single
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            var student = _studentService.GetSingleStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // add student
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            _studentService.AddStudent(student);
            return Ok(student);
        }

        // update student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            student.Id = id;   

            _studentService.UpdateStudent(student);

            return Ok();
        }

        // delete student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}