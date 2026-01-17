using Instructors.Repository;
namespace Instructors.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository traineeRepo;
        private readonly ICrsResultRepository crsResultRepo;
        public TraineeController(ITraineeRepository _traineeRepo, ICrsResultRepository _crsResultRepo) 
        {
            traineeRepo = _traineeRepo;
            crsResultRepo = _crsResultRepo;
        }
        public IActionResult ShowResult(int id , int crsId)
        {
            if(id==0 || crsId==0)
            {
                return View("Index");
            }

            var Result=crsResultRepo.GetByIdAndCrsId(id, crsId);
            if (Result==null)
            {
                return View("Index");
            }
            var ResultStudentToView = new ShowResultViewModel()
            {
               TraineeName= Result?.Trainee.Name,
                CourseName= Result?.Course.Name,
                Trainee_id= id,
                Crs_id= crsId,
                DegreeStudent= Result?.Degree,
                color= (Result?.Degree >= Result?.Course.MinDegree) ? "Green" : "Red",
                Result= (Result?.Degree >= Result?.Course.MinDegree) ? "Pass" : "Fail"

            };

        
            return View("ShowResult",ResultStudentToView);
        }
        public IActionResult Add()
        {
            return View("Index");
        }
    }
}
