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
using TestCaseStorage.Models.TestCases;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class TestCaseController : Controller
    {
        private readonly ITestCaseService TestCaseService;
        private readonly IBacklogService BacklogService;
        private readonly IUserService UserService;

        public TestCaseController()
        {
            var unitOfWork = new TCTSUnitOfWork(new TCTSDataContext());

            TestCaseService = new TestCaseService(unitOfWork);
            BacklogService = new BacklogDbService(unitOfWork);
            UserService = new UserDbService(unitOfWork);
        }

        [HttpGet]
        public ViewResult List()
        {
            var testCasesListModel = Mapper.Map<IEnumerable<TestCaseListViewModel>>(TestCaseService.GetAllTestCases());

            return View("List", testCasesListModel);
        }

        [HttpGet]
        public ViewResult Add()
        {
            var viewModel = new TestCaseAddViewModel
            {
                BacklogItems = BacklogService.GetAllBacklogItems().ToSelectList(t => t.Title, t => t.ID)
            };

            return View("Add", viewModel);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var testCaseViewModel = Mapper.Map<TestCaseEditViewModel>(TestCaseService.GetTestCaseById(id));
            testCaseViewModel.BacklogItems = BacklogService.GetAllBacklogItems().ToSelectList(t => t.Title, t => t.ID);

            return View("Edit", testCaseViewModel);
        }

        [HttpPost]
        public RedirectToRouteResult AddNew(TestCaseAddViewModel testCase)
        {
            var testCaseDto = Mapper.Map<TestCaseDto>(testCase);
            testCaseDto.CreatedByID = (int) Membership.GetUser(User.Identity.Name).ProviderUserKey;
            TestCaseService.AddNew(testCaseDto);

            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToRouteResult Update(TestCaseEditViewModel testCase)
        {
            var testCaseDto = Mapper.Map<TestCaseDto>(testCase);
            testCaseDto.RunByID = (int)Membership.GetUser(User.Identity.Name).ProviderUserKey;

            TestCaseService.Update(testCaseDto);

            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            TestCaseService.DeleteTestCase(id);

            return RedirectToAction("List");
        }
    }
}