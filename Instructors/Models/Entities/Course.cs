using System.ComponentModel.DataAnnotations.Schema;

namespace Instructors.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Degree { get; set; }
        public float  MinDegree { get; set; }
        public float Hours { get; set; }
        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        public Department Department { get; set; }= null!;
        public List<Instructor>? Instructors { get; set; }
        public List<CrsResult>? CrsResults { get; set; }

    }
}
