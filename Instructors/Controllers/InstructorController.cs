
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Instructors.Controllers
{
    [HandleError]
    [Authorize]
    public class InstructorController : Controller
    {
        
        private readonly IInstructorRepository instRepo;
        private readonly IDepartmentRepository deptRepo;
        private readonly ICourseRepository crsRepo;

        public InstructorController(IInstructorRepository _InstRepo,IDepartmentRepository _deptRepo ,ICourseRepository _crsRepo)
        {
            instRepo = _InstRepo;
            deptRepo = _deptRepo;
            crsRepo = _crsRepo;
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = instRepo.GetAll();
            return View("Index", instructors);
        }
        public IActionResult Details(int id)
        {
            Instructor? instructor = instRepo.GetByIdIncludeDeptAndCourse(id);
            return View("Details", instructor);
        }
        public IActionResult Edit(int id)
        {
            Instructor? ins = instRepo.GetById(id);
            if (ins is null) return View("index");
            InstructorCreateViewModel ICVM= GetInstructorCreateViewModel(null, ins);
            return View(ICVM);
        }
        [HttpPost]
        public IActionResult Edit(InstructorCreateViewModel InsFromView)
        {
            if (ModelState.IsValid)
            {
                if (InsFromView.Dept_id == 0)
                {
                    ModelState.AddModelError("Dept_id", "Please Select Department");
                }
                else if (InsFromView.Crs_id == 0)
                {
                    ModelState.AddModelError("Crs_id", "Please Select Course");
                }
                else
                {
                    Instructor ins = new Instructor()
                    {
                        Id = InsFromView.Id,
                        Name = InsFromView.Name,
                        Image = InsFromView.Image,
                        Salary = (InsFromView.Salary is null) ? 0 : (float)InsFromView.Salary,
                        Address = InsFromView.Address,
                        Dept_id = InsFromView.Dept_id,
                        Crs_id = InsFromView.Crs_id
                    };
                    instRepo.Update(ins);
                    instRepo.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            InsFromView = GetInstructorCreateViewModel(InsFromView, null);

            return View("Edit", InsFromView);
        }
        public IActionResult Delete(int id)
        {
            return PartialView("_DeleteView");
        }
      
        public IActionResult AddInstructor()
        {
            InstructorCreateViewModel ICVM = GetInstructorCreateViewModel(null,null);

            return View("AddInstructor" , ICVM);
        }
        [HttpPost]
        public IActionResult SaveInstructor(InstructorCreateViewModel InsFromView)
        {
            if (ModelState.IsValid)
            {
                if (InsFromView.Dept_id == 0)
                {
                    ModelState.AddModelError("Dept_id", "Please Select Department");
                }
                else if (InsFromView.Crs_id == 0)
                {
                    ModelState.AddModelError("Crs_id", "Please Select Course");
                }
                else
                {
                    Instructor ins = new Instructor()
                    {
                        
                        Name = InsFromView.Name,
                        Image = InsFromView.Image,
                        Salary = (InsFromView.Salary is null) ? 0 : (float)InsFromView.Salary,
                        Address = InsFromView.Address,
                        Dept_id = InsFromView.Dept_id,
                        Crs_id = InsFromView.Crs_id
                    };
                    instRepo.Add(ins);
                    instRepo.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            InsFromView=GetInstructorCreateViewModel(InsFromView,null);

            return View("AddInstructor",InsFromView);
        }
       
        
        private InstructorCreateViewModel GetInstructorCreateViewModel(InstructorCreateViewModel? insFromAction, Instructor? ins)
        {
            InstructorCreateViewModel ICVM;
            if (insFromAction == null) { ICVM = new(); }
            else { ICVM = insFromAction; }
            
            if (ins is not null)
            {
                ICVM.Id = ins.Id;
                ICVM.Name = ins.Name;
                ICVM.Image = ins.Image!;
                ICVM.Salary = ins.Salary;
                ICVM.Address = ins.Address;
                ICVM.Dept_id = ins.Dept_id;
                ICVM.Crs_id = ins.Crs_id;
            }

            List<Department> departments = deptRepo.GetAll();
            List<Course> courses = crsRepo.GetCoursesByDeptId(ICVM.Dept_id).ToList();
            ICVM.Courses = courses;
            ICVM.Departments = departments;
            return ICVM;
        }
    }
}
