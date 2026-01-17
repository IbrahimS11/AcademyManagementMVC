using Instructors.Models;

namespace Instructors.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private AppDbContext context;
        public CourseRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Course> GetAll(int PagesToSkip , int NumberOfCoursesPerPage)
        {
            
            List<Course> courses = context.Courses
                .Skip(PagesToSkip)
                .Take(NumberOfCoursesPerPage)
                .ToList();

            return courses;
        }
        public void Add(Course Course)
        {
            context.Courses.Add(Course);
        }

        public void Update(Course Course)
        {
            context.Update(Course);
        }

        public void Delete(int id)
        {
            var course = GetById(id);
            if (course != null)
            {
                context.Courses.Remove(course);
            }
        }

        public Course? GetById(int id)
        {
            return context.Courses.Find(id);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public int GetTotalCoursesCount()
        {
            return context.Courses.Count();
        }

        public List<Course> GetCoursesByDeptId(int deptId)
        {
            return context.Courses.Where(x=>x.Dept_id==deptId).ToList();
        }
    }
}
