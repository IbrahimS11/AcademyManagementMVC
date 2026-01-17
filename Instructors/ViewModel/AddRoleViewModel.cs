using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Instructors.ViewModel
{
    public class AddRoleViewModel
    {
        [Required(ErrorMessage ="Must be enter Role")]
        [Display(Name ="Role Name")]

        public string RoleName { get; set; }
    }
}
