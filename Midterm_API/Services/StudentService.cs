using Midterm_API.DAL;
using Midterm_API.Entities;

namespace Midterm_API.Services
{
	public class StudentService
	{
		private StudentRepository _repository;

		public StudentService(StudentRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<Student> GetAllStudents()
		{
			var list = _repository.GetAll();
			return list.OrderBy(x => x.Id);
		}

		//Create GetSingleStudent method here 
		//Accept "id" as parameter and return Student

		public Student GetSingleStudent(int id)
		{
			return _repository.GetById(id);
		}

		//Create AddStudent method here 
		//Accept Student object as parameter and return void

		public void AddStudent(Student student)
		{
			if (student != null)
			{
				_repository.Add(student);
			}
		}

		//Create UpdateStudent method here 
		//Accept Student object as parameter and return void

		public void UpdateStudent(Student student)
		{
			if (student != null)
			{
				_repository.Update(student);
			}
		}

		//Create DeleteStudent method here 
		//Accept "id" as parameter and return void

		public void DeleteStudent(int id)
		{
			_repository.Delete(id);
		}
	}
}
