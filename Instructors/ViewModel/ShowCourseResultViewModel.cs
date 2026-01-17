using Instructors.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instructors.ViewModel
{
    public class ShowCourseResultViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Degree { get; set; }
        public float MinDegree { get; set; }
        public float Hours { get; set; }
        public string DepartmentName { get; set; }
        public List<ShowResultViewModel> ShowResultViewModels { get; set; } = null!;
        
    }
}
