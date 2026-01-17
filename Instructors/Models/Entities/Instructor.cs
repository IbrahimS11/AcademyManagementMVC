using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instructors.Models
{
    public class Instructor
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
        public string? Image { get; set; }

        public float Salary { get; set; }
        public string Address { get; set; }

        
        [ForeignKey("Department")]
        public int Dept_id { get; set; }

        [ForeignKey("Course")]
        public int Crs_id { get; set; }

        public Department Department { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
