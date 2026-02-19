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
        public IActionResult GetStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        private object GetStudent()
        {
            throw new NotImplementedException();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            var existingStudent = _studentService.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _studentService.UpdateStudent(student);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _studentService.DeleteStudent(id);
            return NoContent();
        }


        //GET
        //Create GetSingle endpoint here with "id" as parameter
        //return OK if found, NotFound if not found


        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter



        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body



        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter

    }
}
