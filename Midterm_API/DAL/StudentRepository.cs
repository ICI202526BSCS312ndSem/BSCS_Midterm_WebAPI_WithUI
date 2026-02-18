using Microsoft.AspNetCore.Http.HttpResults;
using Midterm_API.Entities;

namespace Midterm_API.DAL
{
    public class StudentRepository
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { 
                Id = 1,
                StudentNumber = "2026-0001", 
                FullName = "Juan dela Cruz", 
                Course = "BSCS",
                Year = 3,
                Section = 3 },
            new Student {
                Id = 2,
                StudentNumber = "2026-0002",
                FullName = "Pedro Penduko",
                Course = "BSCS",
                Year = 2,
                Section = 4 },
        };

        public IEnumerable<Student> GetAll() => _students;

        public Student GetById(int id) => _students.FirstOrDefault(p => p.Id == id);

        public void Add(Student Student)
        {
            Student.Id = _students.Max(p => p.Id) + 1;
            _students.Add(Student);
        }
        public void Update(Student Student)
        {
            var existing = GetById(Student.Id);
            if (existing != null)
            {
                existing.StudentNumber = Student.StudentNumber;
                existing.FullName = Student.FullName;
                existing.Course = Student.Course;
                existing.Year = Student.Year;
                existing.Section = Student.Section;
            }
        }
        public void Delete(int id) => _students.RemoveAll(p => p.Id == id);
    }
}
