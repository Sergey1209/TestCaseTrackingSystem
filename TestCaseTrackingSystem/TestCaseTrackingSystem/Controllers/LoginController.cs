using System;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using DataAccess;
using DataAccess.Repositories.Implementation;
using Services.DTO;
using Services.Implementation;
using Services.Interfaces;
using TestCaseStorage.Models.Login;
using TestCaseStorage.Models.Users;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private IUserService UserService { get; }

        public LoginController()
        {
            UserService = new UserDbService(new TCTSUnitOfWork(new TCTSDataContext()));
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View("Index");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid && Membership.ValidateUser(loginModel.Login, loginModel.Password))
            {
                FormsAuthentication.SetAuthCookie(loginModel.Login, true);

                return RedirectToAction("Index", "Home");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            try
            {
                UserService.AddNew(Mapper.Map<UserDto>(user));

                return Login(new LoginModel {Login = user.Login, Password = user.Password});
            }
            catch (Exception)
            {
                return RedirectToAction("Login");
            }
        }
    }
}