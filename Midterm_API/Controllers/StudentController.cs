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

        // GET: api/Student/5
        [HttpGet("{id}")]
        public IActionResult GetSingleStudent(int id)
        {
            var student = _studentService.GetSingleStudent(id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest("Invalid student data.");
            }

            _studentService.AddStudent(newStudent);

            // Return 201 Created and the student object
            return CreatedAtAction(nameof(GetSingleStudent), new { id = newStudent.Id }, newStudent);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var existingStudent = _studentService.GetSingleStudent(id);

            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} not found for update.");
            }

            // Ensure the ID in the object matches the ID in the URL
            updatedStudent.Id = id;
            _studentService.UpdateStudent(updatedStudent);

            return Ok(new { message = "Student updated successfully." });
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existingStudent = _studentService.GetSingleStudent(id);

            if (existingStudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _studentService.DeleteStudent(id);

            return Ok(new { message = $"Student with ID {id} deleted successfully." });
        }
    }
}