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
        //Accept "id" as parameter and return Student



        //Create AddStudent method here
        //Accept Student object as parameter and return void



        //Create UpdateStudent method here
        //Accept Student object as parameter and return void



        //Create DeleteStudent method here
        //Accept "id" as parameter and return void
    }
}
