using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using DataAccess;
using DataAccess.Repositories.Implementation;
using Services.DTO;
using Services.Implementation;
using Services.Interfaces;
using TestCaseStorage.Models.Users;

namespace TestCaseStorage.Controllers
{
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
            var usersListModel = Mapper.Map<IEnumerable<UserViewModel>>(UserService.GetAllUsers());

            return View("List", usersListModel);
        }

        [HttpGet]
        public ViewResult Show(int id)
        {
            var userModel = Mapper.Map<UserViewModel>(UserService.GetUserById(id));

            return View("Show", userModel);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View("Edit");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var userModel = Mapper.Map<UserViewModel>(UserService.GetUserById(id));

            return View("Edit", userModel);
        }

        [HttpPost]
        public RedirectToRouteResult Save(UserViewModel user)
        {
            if (user.IsNew)
            {
                UserService.AddNew(Mapper.Map<UserDto>(user));
            }
            else
            {
                UserService.Update(Mapper.Map<UserDto>(user));
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToRouteResult Delete(int id)
        {
            UserService.DeleteUser(id);

            return RedirectToAction("List");
        }
    }
}