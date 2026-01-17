
using Microsoft.AspNetCore.Authorization;

namespace Instructors.Controllers
{
    
    [Authorize]
    public class CourseController : Controller
    {
        // AppDbContext context;

        ICourseRepository CourseRepository;
        IDepartmentRepository DepartmentRepository;
        public CourseController(ICourseRepository _crsRepo , IDepartmentRepository _deptRepo)
        {
           // context = new AppDbContext();
            CourseRepository = _crsRepo;
            DepartmentRepository = _deptRepo;
        }   
        public IActionResult Index(int numberOfPage=0)
        {
            int TotalPages = (int)Math.Ceiling(CourseRepository.GetTotalCoursesCount() / 8.0);

            if(numberOfPage < 0) numberOfPage = 0;
            else if(numberOfPage>=TotalPages) numberOfPage = TotalPages-1;

            int NumberOfCoursesPerPage = 8;
            int PagesToSkip = numberOfPage* NumberOfCoursesPerPage;
            
            
            List<Course> courses = CourseRepository.GetAll(PagesToSkip, NumberOfCoursesPerPage);//context.Courses.ToList();
            ViewBag.CurrentPage = numberOfPage;
            ViewBag.TotalPages = TotalPages;


            return View("Index",courses);
        }
       
        public IActionResult Edit(int id)
        {
            Course? crs = CourseRepository.GetById(id);//context.Courses.Find(id);
            if (crs is null)
            {
                return View("index");
            }
            CourseCreateViewModel model = new CourseCreateViewModel();
            CopyDataFromModelToViewModel(crs, model);
            model.Departments = GetDepartments();
            return View("Edit",model);
        }

        [HttpPost]
        public IActionResult UpdateCourse(CourseCreateViewModel CrsFromView)
        {
            if (CrsFromView.Dept_id == 0)
            {
                ModelState.AddModelError("Dept_id", "Please Select Department");
            }
            else if (ModelState.IsValid)
            {
                Course? crs = CourseRepository.GetById(CrsFromView.Id);//context.Courses.Find(CrsFromView.Id);
                if (crs is null)
                {
                    return View("Index");
                }
                CopyDataFromViewModelToModel(CrsFromView, crs);
                CourseRepository.Update(crs); //context.Courses.Update(crs);
                CourseRepository.SaveChanges(); //context.SaveChanges();
                return RedirectToAction("Index");
            }
            CrsFromView.Departments = GetDepartments();
            return View("Edit", CrsFromView);
        }
        public IActionResult AddCourse()
        {
            CourseCreateViewModel model = new CourseCreateViewModel();
            model.Departments = GetDepartments();

            return View("AddCourse", model);

        }

        [HttpPost]
        public IActionResult SaveCourse(CourseCreateViewModel CrsFromView)
        {
            //if (CrsFromView.MinDegree >= CrsFromView.Degree)
            //{
            //    ModelState.AddModelError("MinDegree", "Min Degree Must Be Less Than Degree");
            //}
             if (CrsFromView.Dept_id == 0)
            {
                ModelState.AddModelError("Dept_id", "Please Select Department");
            }
            
            else if (ModelState.IsValid)
            {
                Course crs = new Course();
                CopyDataFromViewModelToModel(CrsFromView, crs);

                CourseRepository.Add(crs);// context.Courses.Add(crs);
                CourseRepository.SaveChanges(); // context.SaveChanges();
                return RedirectToAction("GetAll");
            }

            CrsFromView.Departments = GetDepartments();
            return View("AddCourse",CrsFromView);
            
        }


        public IActionResult TestMinDegreeLessThanDegree(float MinDegree, float Degree)
        {
            if (MinDegree >= Degree)
            {
                return Json($"Min Degree Must Be Less Than Degree");
            }
            return Json(true);
        }

        public IActionResult ShowCourseResult(int id,[FromServices]ICrsResultRepository crsResultRepository)
        {
            ShowCourseResultViewModel courseResultViewModel = new ShowCourseResultViewModel();
            Course? course = CourseRepository.GetById(id); //context.Courses.FirstOrDefault(x=>x.Id==id);
            if (course is null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                courseResultViewModel.Id = course.Id;
                courseResultViewModel.Name = course.Name;
                courseResultViewModel.Degree = course.Degree;
                courseResultViewModel.MinDegree = course.MinDegree;
                courseResultViewModel.Hours = course.Hours;
                courseResultViewModel.DepartmentName = DepartmentRepository.GetById(course.Dept_id)!.Name; //context.Departments.FirstOrDefault(x => x.ID == course.Dept_id)!.Name;
                List<CrsResult> results = crsResultRepository.GetCoureseResultWithTrainee(id); //context.CrsResults.Include(x=>x.Trainee).Where(x => x.Crs_id == id).ToList();

                //حساب نسبة كام في المية لكل طالب
                float MaxDegree = course.Degree;
                float MinDegree = (int)course.MinDegree;
               
                //float percent=results.

                courseResultViewModel.ShowResultViewModels = new List<ShowResultViewModel>();
                foreach (var result in results)
                {
                    float Degree = result.Degree;
                    float percent = (Degree / MaxDegree) * 100;
                    ShowResultViewModel resultViewModel = new ShowResultViewModel()
                    {
                        TraineeName = result.Trainee.Name,
                        Trainee_id = result.Trainee_id,
                        Crs_id = result.Crs_id,
                        DegreeStudent = result.Degree,
                        color = (result.Degree >= MinDegree) ? "Green" : "Red",
                        Result = (result.Degree >= MinDegree) ? $"{percent}%  Pass" : $"{percent}%  Fail"
                    };
                    courseResultViewModel.ShowResultViewModels.Add(resultViewModel);
                }
            }
                return View("ShowCourseResult", courseResultViewModel);
        }

        public IActionResult Delete(int id)
        {
            Course? course = CourseRepository.GetById(id);//context.Courses.Find(id);
            if (course is not null)
            {
                CourseRepository.Delete(id);//context.Courses.Remove(course);
                CourseRepository.SaveChanges();//context.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        public IActionResult GetCoursesByDeptId(int deptId)
        {
            var courses = CourseRepository.GetCoursesByDeptId(deptId);
            return Json(courses);
        }


        //------------------- Private Methods ------------------//
        private void CopyDataFromViewModelToModel(CourseCreateViewModel source, Course destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Degree = source.Degree is not null? (float)source.Degree : 0;
            destination.MinDegree = source.MinDegree is not null ? (float)source.MinDegree : 0;
            destination.Hours = source.Hours is not null ? (float)source.Hours : 0;
            destination.Dept_id = source.Dept_id;
        }
        private void CopyDataFromModelToViewModel(Course source, CourseCreateViewModel destination)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Degree = source.Degree;
            destination.MinDegree = source.MinDegree;
            destination.Hours = source.Hours;
            destination.Dept_id = source.Dept_id;
        }
        private List<Department> GetDepartments()
        {
            return DepartmentRepository.GetAll();//context.Departments.ToList();
        }
        
    }
}
