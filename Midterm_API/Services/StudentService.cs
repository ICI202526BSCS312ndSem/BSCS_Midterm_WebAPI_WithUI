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

        internal void AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        internal void AddStudent(object student)
        {
            throw new NotImplementedException();
        }

        internal void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        internal object GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        internal void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
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
