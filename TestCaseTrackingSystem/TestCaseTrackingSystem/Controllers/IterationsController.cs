using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Implementation;
using TestCaseStorage.Models.Iterations;

namespace TestCaseStorage.Controllers
{
    public class IterationsController : Controller
    {
        private ITCTSUnitOfWork UnitOfWork { get; }

        public IterationsController()
        {
            UnitOfWork = new TCTSUnitOfWork(new TCTSDataContext());
        }

        [HttpGet]
        public ViewResult List()
        {
            var iterations = UnitOfWork.IterationRepository.GetAll().Select(t => new Iteration
            {
                ID = t.ID,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate
            });

            return View("List", iterations);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View("Edit");
        }

        [HttpGet]
        public ViewResult Edit(int iterationId)
        {
            var iteration = UnitOfWork.IterationRepository.GetById(iterationId);

            var iterationModel = new Iteration
            {
                ID = iteration.ID,
                Name = iteration.Name,
                StartDate = iteration.StartDate,
                EndDate = iteration.EndDate
            };

            return View("Edit", iterationModel);
        }

        [HttpPost]
        public ActionResult Delete(int iterationId)
        {
            UnitOfWork.IterationRepository.Remove(UnitOfWork.IterationRepository.GetById(iterationId));
            UnitOfWork.Save();

            return Redirect("List");
        }

        [HttpPost]
        public ActionResult Save(Iteration iteration)
        {
            if (iteration.ID == 0)
            {
                UnitOfWork.IterationRepository.Add(new DataAccess.Entities.Iteration
                {
                    Name = iteration.Name,
                    StartDate = iteration.StartDate,
                    EndDate = iteration.EndDate
                });
            }
            else
            {
                var iterationEntity = UnitOfWork.IterationRepository.GetById(iteration.ID);
                iterationEntity.Name = iteration.Name;
                iterationEntity.StartDate = iteration.StartDate;
                iterationEntity.EndDate = iterationEntity.EndDate;
            }

            UnitOfWork.Save();

            return Redirect("List");
        }
    }
}