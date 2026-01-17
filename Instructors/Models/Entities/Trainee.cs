using System.ComponentModel.DataAnnotations.Schema;

namespace Instructors.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Image { get; set; }
        public float? Grade { get; set; }
        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        public Department Department { get; set; } = null!;
        public List<CrsResult>? CrsResults { get; set; }
    }
}
