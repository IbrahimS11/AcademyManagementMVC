namespace Instructors.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public List<Trainee>? Trainees { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<Course>? Courses { get; set; }

    }
}
