using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Instructors.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(AddRoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                //save role in database
                IdentityResult resultSaveRole = await roleManager.CreateAsync(new IdentityRole { Name =roleViewModel.RoleName });
                if(resultSaveRole.Succeeded)
                {
                    return Content("Role Saved Successfully");
                }
                foreach(var error in resultSaveRole.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View("AddRole" , roleViewModel);
        }
    }
}
