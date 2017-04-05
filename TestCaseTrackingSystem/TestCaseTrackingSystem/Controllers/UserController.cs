using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Implementation;
using Services.DTO;
using Services.Exceptions;
using Services.Implementation;
using Services.Interfaces;
using TestCaseStorage.Models.Users;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService UserService { get; }

        public UserController()
        {
            UserService = new UserDbService(new TCTSUnitOfWork(new TCTSDataContext()));
        }

        [HttpGet]
        public ViewResult List()
        {
            ViewBag.DisableAdd = !User.IsInRole(UserRole.Admin.ToString());
            var usersListModel = Mapper.Map<IEnumerable<UserViewModel>>(UserService.GetAllUsers());

            return View("List", usersListModel);
        }

        [HttpGet]
        public ViewResult Add(string[] errorMessages = null)
        {
            return View("Add", new UserViewModel {ErrorMessages = errorMessages});
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var userModel = Mapper.Map<UserViewModel>(UserService.GetUserById(id));

            return View("Edit", userModel);
        }

        [HttpPost]
        public RedirectToRouteResult Update(UserViewModel user)
        {
            UserService.Update(Mapper.Map<UserDto>(user));

            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            UserService.DeleteUser(id);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult AddNew(UserViewModel user)
        {
            try
            {
                UserService.AddNew(Mapper.Map<UserDto>(user));

                return RedirectToAction("List");
            }
            catch (DuplicateUserException exception)
            {
                return Add(new[] { exception.Message });
            }
        }
    }
}