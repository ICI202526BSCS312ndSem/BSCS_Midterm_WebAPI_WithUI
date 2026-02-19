using System.ComponentModel.DataAnnotations;

namespace Midterm_API.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Section { get; set; }
    }
}


    