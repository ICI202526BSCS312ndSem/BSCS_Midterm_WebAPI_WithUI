using Microsoft.AspNetCore.Mvc;
using Midterm_API.Entities;
using Midterm_API.Services;

namespace Midterm_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private StudentService _studentService;

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

		// GET
		// Create GetSingle endpoint here with "id" as parameter
		// return OK if found, NotFound if not found

		[HttpGet("{id}")]
		public IActionResult GetSingle(int id)
		{
			var student = _studentService.GetSingleStudent(id);

			if (student == null)
			{
				return NotFound();
			}

			return Ok(student);
		}

		// POST
		// Create AddStudent endpoint here
		// Accept Student object as parameter

		[HttpPost]
		public IActionResult AddStudent([FromBody] Student student)
		{
			if (student == null)
			{
				return BadRequest();
			}

			_studentService.AddStudent(student);
			return Ok(student);
		}

		// PUT
		// Create UpdateStudent endpoint here
		// Accept "id" as parameter and student object as body

		[HttpPut("{id}")]
		public IActionResult UpdateStudent(int id, [FromBody] Student student)
		{
			if (student == null)
			{
				return BadRequest();
			}
            
			student.Id = id;   

			_studentService.UpdateStudent(student);

			return Ok();
		}

		// DELETE
		// Create DeleteStudent endpoint here
		// Accept "id" as parameter

		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(int id)
		{
			_studentService.DeleteStudent(id);
			return Ok();
		}
	}
}
