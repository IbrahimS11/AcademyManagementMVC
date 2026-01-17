
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Instructors.ViewModel.ValidationAttributes;
namespace Instructors.ViewModel
{
    public class DepartmentCreateViewModel
    {
        public int ID { get; set; }
        [Required]
        [UniqueNameDept]
        public string Name { get; set; } = null!;
        [Required]
        public string Manager { get; set; } = null!;
        [ValidateNever]
        public List<Trainee>? Trainees { get; set; }
        [ValidateNever]
        public List<Instructor>? Instructors { get; set; }
        [ValidateNever]
        public List<Course>? Courses { get; set; }
    }
}
