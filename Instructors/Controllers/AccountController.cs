using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Instructors.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Register()
        {
            RegisterUserViewModel registerViewModel = new RegisterUserViewModel();

            registerViewModel.Roles =roleManager.Roles.ToList();
            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterSave(RegisterUserViewModel RUVM)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = RUVM.UserName;
                applicationUser.Email = RUVM.Email;


                //save in database
                var results = await userManager.CreateAsync(applicationUser, RUVM.Password);

                if (results.Succeeded)
                {
                    //add Role to user
                    await userManager.AddToRoleAsync(applicationUser, "admin");
                    //caching
                    await signInManager.SignInAsync(applicationUser, isPersistent: false);

                    return RedirectToAction("Index", "Course");
                }
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View("Register", RUVM);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                 var result = await userManager.FindByNameAsync(userViewModel.Name);
                if(result is not null)
                {
                    bool found = await userManager.CheckPasswordAsync(result, userViewModel.Password);
                    if (found)
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("City", "Cairo"));

                        // if i want add claims
                        await signInManager.SignInWithClaimsAsync(result, userViewModel.SaveAccount, claims); 
                            

                            //if i don't want add any claim
                           // await signInManager.SignInAsync(result, userViewModel.SaveAccount);
                        
                         return RedirectToAction("Index", "Course");
                    }
                }
                ModelState.AddModelError("", "the Name or Password is Wrong");
            }
            return View("Login",userViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return View("Login");
        }
    }

    
}
