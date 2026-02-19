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
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }


        //GET
        //Create GetSingle endpoint here with "id" as parameter
        //return OK if found, NotFound if not found
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingle(int id)
        {
            var student = _studentService.GetSingleStudent(id);
            return student != null ? Ok(student) : NotFound();
        }


        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            //return 400 if course and section is zero or below (validation)
            if (student == null ||
                student.Year <= 0 ||
                student.Section <= 0)
            {
                return BadRequest();
            }

            _studentService.AddStudent(student);
            return StatusCode(201);
        }


        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var existingStudent = _studentService.GetSingleStudent(id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            //return 400 if course and section is zero or below (validation)
            if (student == null ||
                student.Year <= 0 ||
                student.Section <= 0)
            {
                return BadRequest();
            }

            student.Id = id;
            _studentService.UpdateStudent(student);
            return StatusCode(204);
        }


        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existingStudent = _studentService.GetSingleStudent(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}