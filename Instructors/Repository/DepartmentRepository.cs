using Instructors.Models;

namespace Instructors.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private AppDbContext context;
        public DepartmentRepository()
        {
            context = new AppDbContext();
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public void Add(Department Department)
        {
            context.Departments.Add(Department);
        }

        public void Update(Department Department)
        {
            context.Update(Department);
        }

        

        public Department? GetById(int id)
        {
            return context.Departments.Find(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var Department = GetById(id);
            if (Department is null) return false;
            
            var countTrainee = context.Trainees.Where(t=>t.Dept_id==id).Count();
            if (countTrainee > 0) return false;


            var countInst = context.Instructors.Where(t => t.Dept_id == id).Count();
            if (countInst > 0) return false;


            var countcourse = context.Courses.Where(t => t.Dept_id == id).Count();
            if (countcourse > 0) return false;

            context.Departments.Remove(Department);
            return true;
        }

    }
}
