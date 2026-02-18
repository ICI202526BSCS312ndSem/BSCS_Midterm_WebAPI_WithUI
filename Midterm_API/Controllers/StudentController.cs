using Microsoft.AspNetCore.Mvc;
using Midterm_API.Entities;
using Midterm_API.Services;
using System;

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
        public IActionResult GetSingle(int id)
        {
            //retuns NotFound if GetSingleStudent(id) did not return a value
            if (null == _studentService.GetSingleStudent(id))
            {
                return NotFound();
            } //success
            else {
                _studentService.GetSingleStudent(id);
                return Ok(_studentService.GetSingleStudent(id));
            }

        }

        //POST
        //Create AddStudent endpoint here
        //Accept Student object as parameter
        [HttpPost]
        public IActionResult Add(Student student)
        {
            //returns BadRequest if student is null
            if (student == null)
            {
                return BadRequest();
            }
            //returns BadRequest if year and section is negative value
            if (student.Year <= -1 || student.Section <= -1)
            {
                return BadRequest();
            }
            //success
            else
            {
                _studentService.AddStudent(student);
                return StatusCode(201);
            }
        }

        //PUT
        //Create UpdateStudent endpoint here
        //Accept "id" as parameter and Student object as body
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {

             student.Id = id;
            //returns NotFound id student is null
            if(student == null)
            {
                return NotFound();

            }
            //returns BadRequest if year and section is negative value
            if (student.Year <= -1 || student.Section <= -1)
            {
                return BadRequest();
            }
            //success
            else
            {
                _studentService.UpdateStudent(student);
                return StatusCode(204);
            }


        }

        //DELETE
        //Create DeleteStudent endpoint here
        //Accept "id" as parameter
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            //deletes a record
            _studentService.DeleteStudent(id);
            return Ok();
        }


    }
}