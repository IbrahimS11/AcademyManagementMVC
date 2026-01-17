using Microsoft.AspNetCore.Mvc;

namespace Instructors.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository deptRepo;
        private readonly ICourseRepository crsRepo;

        public DepartmentController(IDepartmentRepository _deptRepo ,ICourseRepository _crsRepo)
        {
            deptRepo = _deptRepo;
            crsRepo = _crsRepo;
        }
        public IActionResult Index()
        {
            List<Department> departments = deptRepo.GetAll();
            DepartmentCreateViewModel deptViewModel = new();

            return View(( departments,deptViewModel));
        }
       
        [HttpPost]
        public IActionResult Add([FromBody] DepartmentCreateViewModel deptFromView)
        {
            if (ModelState.IsValid)
            {
                Department Dept = new Department
                {
                    Name = deptFromView.Name,
                    Manager = deptFromView.Manager
                };
                deptRepo.Add(Dept);
                deptRepo.SaveChanges();
                object dept = new { success = true, id = Dept.ID, name = Dept.Name, manager = Dept.Manager };
                return Json(dept);
            }
            return Json(new { success = false });
        }
         
        public IActionResult Delete(int id)
        {
            Department? dept = deptRepo.GetById(id);
          
            if (dept is null)
            {

                object obj = new
                {
                    title = "Error",
                    text = "this Department Not Exist",
                    icon = "warning"
                };
                return Json(obj);

            }
           
            bool testDelete=deptRepo.Delete(id);
            deptRepo.SaveChanges();
            if (testDelete)
            {
                object obj = new
                {
                    title = "Success",
                    text = $"The Department ({dept.Name}) is Deleted Successfuly ",
                    icon = "success"
                };
                return Json(obj);
            }
            object Fail = new
            {
                title = "Fail",
                text = $"This Department ({dept.Name}) Contain Trainee or Courses or Instructors ",
                icon = "error"
            };
            return Json(Fail);
        }
        public IActionResult Edit(int id)
        {
            Department? dept = deptRepo.GetById(id);
            if (dept is null) return RedirectToAction("Index");
            DepartmentCreateViewModel deptViewModel = new DepartmentCreateViewModel
            {
                ID = id,
                Name = dept.Name,
                Manager = dept.Manager
            };
            return View(deptViewModel);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentCreateViewModel deptFromView)
        {
            if(ModelState.IsValid)
            {
                
                    Department dept = new Department
                    {
                        ID=deptFromView.ID,
                        Name = deptFromView.Name,
                        Manager = deptFromView.Manager
                    };
                    deptRepo.Update(dept);
                    deptRepo.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(deptFromView);
        }
        public IActionResult Details(int id) 
        {
            Department? dept=deptRepo.GetById(id);
            if (dept is null) { return RedirectToAction("index"); }
            DepartmentCreateViewModel DeptViewModel = new()
            {
                ID=dept.ID ,
                Name=dept.Name,
                Manager=dept.Manager,
                Courses= crsRepo.GetCoursesByDeptId(dept.ID)

            };
            return View(DeptViewModel);
        }

    }
}
