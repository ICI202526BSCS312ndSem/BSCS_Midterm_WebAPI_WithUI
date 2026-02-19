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

        // 1. GetSingleStudent: Accept "id" as parameter and return Student
        public Student GetSingleStudent(int id)
        {
            return _repository.GetById(id);
        }

        // 2. AddStudent: Accept Student object as parameter and return void
        public void AddStudent(Student newStudent)
        {
            _repository.Add(newStudent);
        }

        // 3. UpdateStudent: Accept Student object as parameter and return void
        public void UpdateStudent(Student updatedStudent)
        {
            _repository.Update(updatedStudent);
        }

        // 4. DeleteStudent: Accept "id" as parameter and return void
        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
        }
    }
}