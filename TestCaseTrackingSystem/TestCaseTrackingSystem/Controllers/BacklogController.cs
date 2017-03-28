using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using DataAccess;
using DataAccess.Repositories.Implementation;
using Services.DTO;
using Services.Implementation;
using Services.Interfaces;
using TestCaseStorage.Infrastructure.Extensions;
using TestCaseStorage.Models.BacklogItems;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class BacklogController : Controller
    {
        private readonly IBacklogService BackogService;
        private readonly IIterationService IterationService;
        private readonly IUserService UserService;
        
        public BacklogController()
        {
            BackogService = new BacklogDbService(new TCTSUnitOfWork(new TCTSDataContext()));
            IterationService = new IterationDbService(new TCTSUnitOfWork(new TCTSDataContext()));
            UserService = new UserDbService(new TCTSUnitOfWork(new TCTSDataContext()));
        }

        [HttpGet]
        public ViewResult List()
        {
            var listModel = Mapper.Map<IEnumerable<BacklogItemViewModel>>(BackogService.GetAllBacklogItems());
            
            return View("List", listModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var editModel = Mapper.Map<BacklogItemEditModel>(new BacklogItemDto());
            editModel.Iterations = IterationService.GetAllIterations().ToSelectList(t => t.Name, t => t.ID);
            editModel.Users = UserService.GetAllUsers().ToSelectList(t => t.Login, t => t.ID);
            editModel.UserCreatedId = (int)Membership.GetUser(User.Identity.Name).ProviderUserKey;

            return View("Add", editModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var currentBacklogItemModel = Mapper.Map<BacklogItemEditModel>(BackogService.GetBacklogItemById(id));
            currentBacklogItemModel.Iterations = IterationService.GetAllIterations().ToSelectList(t => t.Name, t => t.ID, t => t.Name == currentBacklogItemModel.Iteration);
            currentBacklogItemModel.Users = UserService.GetAllUsers().ToSelectList(t => t.Login, t => t.ID, t => t.Login == currentBacklogItemModel.AssignedTo);

            return View("Edit", currentBacklogItemModel);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            BackogService.DeleteBacklogItem(id);

            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToRouteResult Update(BacklogItemEditModel backlogItem)
        {
            BackogService.Update(Mapper.Map<BacklogItemDto>(backlogItem));

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult AddNew(BacklogItemEditModel backlogItem)
        {
            BackogService.AddNew(Mapper.Map<BacklogItemDto>(backlogItem));

            return RedirectToAction("List");
        }
    }
}