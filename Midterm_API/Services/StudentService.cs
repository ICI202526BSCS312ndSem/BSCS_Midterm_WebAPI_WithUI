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

        // get single student
        public Student GetSingleStudent(int id)
        {
            return _repository.GetById(id);
        }

        // add student
        public void AddStudent(Student student)
        {
            if (student != null)
            {
                _repository.Add(student);
            }
        }

        // update student
        public void UpdateStudent(Student student)
        {
            if (student != null)
            {
                _repository.Update(student);
            }
        }

        // delete student
        public void DeleteStudent(int id)
        {
            _repository.Delete(id);
        }
    }
}