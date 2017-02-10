using System.Web.Mvc;
using System.Web.Security;
using TestCaseStorage.Models.Login;

namespace TestCaseStorage.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View("Index");
        }

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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}