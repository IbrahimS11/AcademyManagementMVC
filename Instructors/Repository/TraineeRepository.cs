using Instructors.Models;

namespace Instructors.Repository
{
    public class TraineeRepository:ITraineeRepository
    {
        private AppDbContext context;
        public TraineeRepository()
        {
            context = new AppDbContext();
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees.ToList();
        }
        public void Add(Trainee Trainee)
        {
            context.Trainees.Add(Trainee);
        }

        public void Update(Trainee Trainee)
        {
            context.Update(Trainee);
        }

        public void Delete(int id)
        {
            var trainee = GetById(id);
            if (trainee != null)
            {
                context.Trainees.Remove(trainee);
            }
        }

        public Trainee? GetById(int id)
        {
            return context.Trainees.Find(id);
        }
       

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
