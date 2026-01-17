using Instructors.Models;

namespace Instructors.Repository
{
    public interface ICrsResultRepository
    {
        public List<CrsResult> GetAll();
        public void Add(CrsResult CrsResult);

        public void Update(CrsResult CrsResult);

        public void Delete(int id);

        public CrsResult? GetById(int id);

        public List<CrsResult> GetCoureseResultWithTrainee(int id);
        public CrsResult? GetByIdAndCrsId(int id, int crsId);
        public void SaveChanges();
    }
}
