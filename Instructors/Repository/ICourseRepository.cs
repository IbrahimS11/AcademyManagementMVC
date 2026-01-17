using Instructors.Models;
namespace Instructors.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAll(int PagesToSkip, int NumberOfCoursesPerPage);
        public void Add(Course Course);

        public void Update(Course Course);

        public void Delete(int id);

        public Course? GetById(int id);

        public void SaveChanges();
        public int GetTotalCoursesCount();
        public List<Course> GetCoursesByDeptId(int deptId);
    }
}
