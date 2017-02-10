using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Implementation;
using User = TestCaseStorage.Models.Users.User;

namespace TestCaseStorage.Controllers
{
    public class UserController : Controller
    {
        private ITCTSUnitOfWork UnitOfWork { get; }

        public UserController()
        {
            UnitOfWork = new TCTSUnitOfWork(new TCTSDataContext());
        }

        [HttpGet]
        public ViewResult List()
        {
            var usersModel = UnitOfWork.UserRepository.GetAll().Select(t =>
                    new User
                    {
                        ID = t.ID,
                        Login = t.Login,
                        Password = t.Password,
                        Role = (UserRoleEnum) t.RoleID,
                        Email = t.Email,
                        FirstName = t.FirstName,
                        LastName = t.LastName,
                        DateCreated = t.CreatedDate,
                        LastLoginDate = t.LastLogin
                    }
            );

            return View("List", usersModel);
        }

        [HttpGet]
        public ViewResult Show(string login)
        {
            var user = UnitOfWork.UserRepository.GetByLogin(login);

            var userModel = new User
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = (UserRoleEnum)user.RoleID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                 DateCreated = user.CreatedDate
            };

            return View("Show", userModel);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View("Edit");
        }

        [HttpGet]
        public ViewResult Edit(int userId)
        {
            var user = UnitOfWork.UserRepository.GetById(userId);

            var userModel = new User
            {
                ID = user.ID,
                Login = user.Login,
                Password = user.Password,
                Role = (UserRoleEnum)user.RoleID,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View("Edit", userModel);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            var userEntity = new DataAccess.Entities.User
            {
                Login = user.Login,
                Password = user.Password,
                RoleID = (int)user.Role,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CreatedDate = DateTime.Now,
                Locked = false
            };

            if (user.ID == 0)
            { 
                UnitOfWork.UserRepository.Add(userEntity);
            }
            else
            {
                var existingUser = UnitOfWork.UserRepository.GetById(user.ID);

                existingUser.Login = user.Login;
                existingUser.Password = user.Password;
                existingUser.RoleID = (int) user.Role;
                existingUser.Email = user.Email;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.CreatedDate = DateTime.Now;
                existingUser.Locked = false;
            }

            UnitOfWork.Save();

            return Redirect("List");
        }

        [HttpPost]
        public ActionResult Delete(int userId)
        {
            UnitOfWork.UserRepository.Remove(UnitOfWork.UserRepository.GetById(userId));
            UnitOfWork.Save();

            return Redirect("List");
        }
    }
}