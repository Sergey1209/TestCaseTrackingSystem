using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Implementation;
using TestCaseStorage.Models.BacklogItems;
using BacklogItem = TestCaseStorage.Models.BacklogItems.BacklogItem;

namespace TestCaseStorage.Controllers
{
    public class BacklogController : Controller
    {
        private ITCTSUnitOfWork UnitOfWork { get; }

        public BacklogController()
        {
            UnitOfWork = new TCTSUnitOfWork(new TCTSDataContext());
        }

        [HttpGet]
        public ViewResult List()
        {
            var backlogItems = UnitOfWork.BacklogItemRepository.GetAllBacklogItems().Select(ConvertEntityToViewModel);
            
            return View("List", backlogItems);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Edit", ConvertEntityToEditModel(null));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var backlogItem = UnitOfWork.BacklogItemRepository.GetBacklogItemById(id);
            
            return View("Edit", ConvertEntityToEditModel(backlogItem));
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return Redirect("List");
        }

        [HttpPost]
        public ActionResult Save(BacklogItem backlogItem)
        {
            if (backlogItem.ID == 0)
            {
                var backlogEntity = new DataAccess.Entities.BacklogItem
                {
                    Title = backlogItem.Title,
                    Description = backlogItem.Description,
                    TypeID = (int) backlogItem.Type,
                    IterationID = backlogItem.BelongsToIterationId,
                    AssignedToID = backlogItem.AssignedToUserId,
                    DateCreated = backlogItem.DateCreated,
                    CreatedByID = UnitOfWork.UserRepository.GetByLogin(User.Identity.Name).ID
                };

                UnitOfWork.BacklogItemRepository.Add(backlogEntity);
            }
            else
            {
                // Update code here
            }

            UnitOfWork.Save();

            return Redirect("List");
        }

        private static BacklogItemViewModel ConvertEntityToViewModel(DataAccess.Entities.BacklogItem backlogItemEntity)
        {
            if (backlogItemEntity == null)
            {
                return new BacklogItemViewModel();
            }

            return new BacklogItemViewModel
            {
                ID = backlogItemEntity.ID,
                Title = backlogItemEntity.Title,
                Description = backlogItemEntity.Description,
                DateCreated = backlogItemEntity.DateCreated,
                Type = (BacklogItemTypeEnum)backlogItemEntity.Type.ID,
                BelongsToIteration = backlogItemEntity.Iteration.Name,
                AssignedToUser = backlogItemEntity.AssignedTo.Login,
                UserCreated = backlogItemEntity.CreatedBy.Login
            };
        }

        private BacklogItemEditModel ConvertEntityToEditModel(DataAccess.Entities.BacklogItem backlogItemEntity)
        {
            var backlogItemEditModel = new BacklogItemEditModel
            {
                Iterations = UnitOfWork.IterationRepository.GetAll().Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Name
                }),
                Users = UnitOfWork.UserRepository.GetAll().Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Login
                })
            };

            //var backlogItemEditModel = ConvertEntityToViewModel(backlogItemEntity);


            return backlogItemEditModel;
        }
    }
}