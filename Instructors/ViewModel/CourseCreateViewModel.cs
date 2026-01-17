using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Instructors.Models;
using Microsoft.AspNetCore.Mvc;
namespace Instructors.ViewModel
{
    public class CourseCreateViewModel
    {
        [ValidateNever]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Max Length is 20 character.")]
        [MinLength(2, ErrorMessage = "Min Length is 2 character.")]
        [UniqueAttribute]
        public string Name { get; set; }
        [Required]
        [Range(50, 200, ErrorMessage = "Degree Required Between [50 - 200].")]

        public float? Degree { get; set; }
        [Required]
        [Range(20, 120, ErrorMessage = "MinDegree Required Between [20 - 120].")]
        [Remote(action:"TestMinDegreeLessThanDegree" , controller:"Course",AdditionalFields = "Degree",ErrorMessage ="Min Degree Required Less than Degree.")]
        public float? MinDegree { get; set; } 
        [Required]
        public float? Hours { get; set; }
        [Required]
        public int Dept_id { get; set; }

        public List<Department>? Departments;
    }
}
