using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Instructors.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;


        [Required]
        public string Password { get; set; } = null!;

        [Required,Compare("Password", ErrorMessage = "Passwords do not match.") ]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        public string RoleId { get; set; } = null!;
        public List<IdentityRole> Roles { get; set; } = new List<IdentityRole>();

    }
}
