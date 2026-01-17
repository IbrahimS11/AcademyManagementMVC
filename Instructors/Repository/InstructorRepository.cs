using Instructors.Models;

namespace Instructors.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private AppDbContext context;
        public InstructorRepository() 
        { 
            context = new AppDbContext();
        }

        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }
        public void Add(Instructor instructor)
        {
            context.Instructors.Add(instructor);
        }

        public void Update(Instructor instructor)
        {
            context.Update(instructor);
        }

        public void Delete(int id)
        {
            var instructor = GetById(id);
            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
            }
        }

        public Instructor? GetById(int id)
        {
            return context.Instructors.Find(id);
        }
        public Instructor? GetByIdIncludeDeptAndCourse(int id)
        {
            return context.Instructors.Include(x => x.Department).Include(x => x.Course).FirstOrDefault(x => x.Id == id);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
