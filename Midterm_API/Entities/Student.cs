namespace Midterm_API.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string FullName { get; set; } 
        public string Course { get; set; } 
        public int Year { get; set; }
        public int Section { get; set; }
    }
}
