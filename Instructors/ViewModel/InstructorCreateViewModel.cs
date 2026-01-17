using Instructors.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instructors.ViewModel
{
    public class InstructorCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Min Length is 3 character.")]
        [MaxLength(30, ErrorMessage = "Max Length is 30 character.")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }

        [ValidateNever]
        public string Image { get; set; }

        [Required]
        // [Range(8000, 40000, ErrorMessage = "Salary Required Between [8000 - 40000].")]
        public float? Salary { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public int Dept_id { get; set; }
        [Required]
        public int Crs_id { get; set; }

        [ValidateNever]
        public List<Department> Departments { get; set; }
        [ValidateNever]
        public List<Course> Courses { get; set; } 
    }
}
