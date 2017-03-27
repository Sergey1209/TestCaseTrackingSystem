using System.Web.Mvc;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class NavigationMenuController : Controller
    {
        public ViewResult Show()
        {
            return View("_navigationMenu");
        }
    }
}