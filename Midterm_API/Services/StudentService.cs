using Midterm_API.DAL;
using Midterm_API.Entities;

namespace Midterm_API.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repository;

        public StudentService(StudentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repository.GetAll().OrderByDescending(p => p.Id);
        }

        //Create GetSingleStudent method here
        public Student GetSingleStudent(int id) => _repository.GetById(id);
        //Accept "id" as parameter and return Student

        //Create AddStudent method here
        public void CreateStudent(Student student) => _repository.Add(student);
        //Accept Student object as parameter and return void

        //Create UpdateStudent method here
        public void UpdateStudent(Student student) => _repository.Update(student);
        //Accept Student object as parameter and return void

        //Create DeleteStudent method here
        public void RemoveStudent(int id) => _repository.Delete(id);
        //Accept "id" as parameter and return void
    }
}
