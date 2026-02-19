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
        private Student student;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Get()
        {
            var student = _studentService.GetAllStudents();
            return Ok(student);
        }



        // get single 
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var student = _studentService.GetStudentById(id);
                if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }


        [HttpPost]
        public IActionResult AddStudent( Student student)
        {
            _studentService.AddStudent(student);
            return Ok(_studentService.GetAllStudents());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,  Student student)
        {
            if (id != student.id)
            {
                return BadRequest();
            }
            return Ok(_studentService.GetAllStudents());

            var existingsStudent = _studentService.GetStudentById(id);
            if(existingsStudent == null)
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
