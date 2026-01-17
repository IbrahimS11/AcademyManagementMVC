
namespace Instructors.Repository
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAll();
        public void Add(Instructor Instructor);

        public void Update(Instructor Instructor);

        public void Delete(int id);

        public Instructor? GetById(int id);
        public Instructor? GetByIdIncludeDeptAndCourse(int id);

        public void SaveChanges();
    }
}
