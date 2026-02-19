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

        //GET
        //Create GetSingle endpoint here with "id" as parameter
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = (_studentService.GetSingleStudent(id));
            return student == null ? NotFound() : Ok(student);
        }
        //return OK if found, NotFound if not found


        //POST
        //Create AddStudent endpoint here
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _studentService.CreateStudent(student);
            return Ok();
        }
        //Accept Student object as parameter



        //PUT
        //Create UpdateStudent endpoint here
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Student student)
        {
            student.Id = id;
           _studentService.UpdateStudent(student);
            return Ok(id);
        }
        //Accept "id" as parameter and Student object as body



        //DELETE
        //Create DeleteStudent endpoint here
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.RemoveStudent(id);
            return Ok(id);
        }
        //Accept "id" as parameter
       
    }
}
