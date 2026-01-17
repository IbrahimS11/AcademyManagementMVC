using Instructors.Models;
using Microsoft.EntityFrameworkCore;

namespace Instructors.Repository
{
    public class CrsResultRepository : ICrsResultRepository
    {
        private AppDbContext context;
        public CrsResultRepository()
        {
            context = new AppDbContext();
        }

        public List<CrsResult> GetAll()
        {
            return context.CrsResults.ToList();
        }
        public void Add(CrsResult CrsResult)
        {
            context.CrsResults.Add(CrsResult);
        }

        public void Update(CrsResult CrsResult)
        {
            context.Update(CrsResult);
        }

        public void Delete(int id)
        {
            var CrsResult = GetById(id);
            if (CrsResult != null)
            {
                context.CrsResults.Remove(CrsResult);
            }
        }

        public CrsResult? GetById(int id)
        {
            return context.CrsResults.Find(id);
        }

        public List<CrsResult> GetCoureseResultWithTrainee(int id)
        {
            return context.CrsResults.Include(x => x.Trainee).Where(x => x.Crs_id == id).ToList();
        }
        public CrsResult? GetByIdAndCrsId(int id, int crsId)
        {
            return context.CrsResults.Where(x => (x.Crs_id == crsId && x.Trainee_id == id)).Include(x => x.Trainee).Include(x => x.Course).FirstOrDefault();
        }
        

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
