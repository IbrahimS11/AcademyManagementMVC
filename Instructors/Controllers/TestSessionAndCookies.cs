using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Pkcs;

namespace Instructors.Controllers
{
    public class TestSessionAndCookies : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetSession()
        {
            int Id = 1;
            string Name = "Ibrahim";
            HttpContext.Session.SetInt32("Id", Id);
            HttpContext.Session.SetString("Name", Name);
            return Content("the session Saved successed ");
        }

        public IActionResult GetSession()
        {
           int? Id= HttpContext.Session.GetInt32("Id");
           string Name= HttpContext.Session.GetString("Name")??"No Name";
           return Content($"the session values : Id = {Id} , Name = {Name} ");
        }

        public IActionResult SetCookie()
        {
            //Session Cookie بتفضل شغالة لحد ما مدة الجلسة تخلص بتبقي مدة بسيطة دقايق او ساعات
            HttpContext.Response.Cookies.Append("Id", "1");

            //prersistent Cookie بتفضل شغالة حتى لو المتصفح اتقفل وبتبقي مدة اطول ممكن ايام او شهور
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            HttpContext.Response.Cookies.Append("Name","Ibrahim Samir",options);
            return Content("the Cookie Saved successed ");
        }

        public IActionResult GetCookie()
        {
            string? Id= HttpContext.Request.Cookies["Id"];
            string? Name= HttpContext.Request.Cookies["Name"];
            return Content($"the Cookie values : Id = {Id} , Name = {Name} ");
        }

        //use Idintity to take data from Cookies

        public IActionResult GetCookieByUser()
        {
            ContentResult content = new ContentResult();
            if (User.Identity.IsAuthenticated)
            {
                string NameUser = User.Identity.Name;
                string Id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                string city= User.Claims.FirstOrDefault(c => c.Type == "City")?.Value ?? "No City";
                //string Id = User.Claims[0];
                content.Content = $"Welcome {NameUser} \n Your Id is {Id} \n Your city is {city}";

                return content;
            }
            content.Content = $"Welcome Please Sign up Let Me See You Again";

            return content;


        }

    }
}
