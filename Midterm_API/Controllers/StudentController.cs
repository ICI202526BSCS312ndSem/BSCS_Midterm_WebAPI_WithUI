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
        //return OK if found, NotFound if not found
        [HttpGet("{id}[Controller]")]
        public IActionResult Get(int id)
        {
            var Student = _studentService.GetSingleStudent(id);
            return Student != null ? NotFound(): Ok(Student);
        }

        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _studentService.AddStudent(student);
            return Ok();
        }


        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body
        [HttpPut("{id}[Controller]")]
        public IActionResult Put(int id,[FromBody] Student student)
        {
            student.Id = id;
            _studentService.UpdatedStudent(student);
            return Ok();
        }


        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }
    }
}