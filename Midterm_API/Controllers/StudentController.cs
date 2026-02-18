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


        [HttpGet("{id}[Controller]")]
        public IActionResult Get(int id)
        {
            var Student = _studentService.GetSingleStudent(id);
            return Student == null ? NotFound() : Ok(Student);
        }
        //GET
        //Create GetSingle endpoint here with "id" as parameter
        //return OK if found, NotFound if not found


        [HttpPost]
        public IActionResult Post(int id,[FromBody] Student student)
        {
           
            _studentService.AddStudent(student);

            var Student = _studentService.GetSingleStudent(id);
            return Student == null ? BadRequest() : Created();
        }
        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter

        [HttpPut("{id}[Controller]")]
        public IActionResult Put(int id, [FromBody]Student student)
        {
            _studentService.UpdateStudent(student);

            var Student = _studentService.GetSingleStudent(id);
            return Student == null ? BadRequest() : NoContent();

        }
        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);


            var Student = _studentService.GetSingleStudent(id);
            return Student == null ? NotFound() : Ok(Student);
        }
        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter
       
    }
}