using Microsoft.AspNetCore.Identity;

namespace Instructors.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Address { get; set; }
    }
}
