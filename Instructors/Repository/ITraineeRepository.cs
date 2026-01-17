using Instructors.Models;

namespace Instructors.Repository
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetAll();
        public void Add(Trainee Trainee);

        public void Update(Trainee Trainee);

        public void Delete(int id);

        public Trainee? GetById(int id);

        public void SaveChanges();
    }
}
