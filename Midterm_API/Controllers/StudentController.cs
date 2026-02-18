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


        [HttpGet]
        public IActionResult Get(int id)
        {
            var Student = _studentService.GetSingleStudent(id);
            return Student != null ? NotFound() : Ok(Student);
        }
        //GET
        //Create GetSingle endpoint here with "id" as parameter
        //return OK if found, NotFound if not found


        [HttpPost]
        public IActionResult Post(int id, [FromBody] Student student)
        {

            _studentService.AddStudent(student);
            return Ok();
        }
        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            _studentService.UpdateStudent(student);
            return Ok();
        }
        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok();
        }
        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter

    }
}