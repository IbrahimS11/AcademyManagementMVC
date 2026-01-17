using System.ComponentModel.DataAnnotations.Schema;

namespace Instructors.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public float Degree { get; set; }

        [ForeignKey("Course")]
        public int Crs_id { get; set; }
        [ForeignKey("Trainee")]
        public int Trainee_id { get; set; }
        public Course Course { get; set; } = null!;
        public Trainee Trainee { get; set; } = null!;
    }
}
