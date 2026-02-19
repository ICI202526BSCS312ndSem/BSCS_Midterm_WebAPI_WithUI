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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingStudent = _studentService.GetSingleStudent(id);
            if (existingStudent != null)
            {
                return StatusCode(200, _studentService);
            }
            else
            {
                return StatusCode(404);
            }
        }

        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter
        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            if(student == null)
            {
                return StatusCode(404);
            }
            if(student.Section <= -1 || student.Section <= -1)
            {
                return StatusCode(400);
            }
            else
            {
                _studentService.CreateStudent(student);
                return StatusCode(201);
            }
        }


        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            student.Id = id;
            if (student == null)
            {
                return StatusCode(404);
            }
            if (student.Section <= -1 || student.Section <= -1)
            {
                return StatusCode(400);
            }
            else
            {
                _studentService.UpdateStudent(student);
                return StatusCode(200);
            }
        }



        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStudent = _studentService.GetSingleStudent(id);
            if(existingStudent != null)
            {
                _studentService.RemoveStudent(id);
                return StatusCode(200);
            }
            else
            {
                return StatusCode(404);
            }
        }
       
    }
}