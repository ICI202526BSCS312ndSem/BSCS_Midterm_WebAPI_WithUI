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
        [HttpGet("{id}")]
        //Create GetSingle endpoint here with "id" as parameter
        //return OK if found, NotFound if not found
        public IActionResult Get(int id)
        {
            var student = _studentService.GetSingleStudent(id);
            return student == null ? NotFound() : Ok(student);
        }


        //POST
        [HttpPost]
        //Create AddStudent endpoint here
        //Accept Student object as parameter
        public IActionResult Post([FromBody] Student student)
        {
            _studentService.CreateStudent(student);
            return Ok();
        }



        //PUT
        [HttpPut("{id}")]
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body
        public IActionResult Put(int id, [FromBody] Student student)
        {
            student.Id = id;
            _studentService.UpdateStudent(student);
            return Ok(student);

        }



        //DELETE
        [HttpDelete("{id}")]
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter
        public IActionResult Delete(int id)
        {
            _studentService.RemoveStudent(id);
            return Ok();
        }
        // hi beyb
        // hellow, bakit ka andeto
       
    }
}
