using Instructors.Models;

namespace Instructors.Repository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public void Add(Department Department);

        public void Update(Department Department);

        public bool Delete(int id);

        public Department? GetById(int id);

        public void SaveChanges();
    }
}
