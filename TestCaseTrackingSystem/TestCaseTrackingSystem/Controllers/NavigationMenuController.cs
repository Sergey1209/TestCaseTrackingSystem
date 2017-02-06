using System.Web.Mvc;
using TestCaseStorage.Models.Shared;

namespace TestCaseStorage.Controllers
{
    public class NavigationMenuController : Controller
    {
        public ViewResult Show()
        {
            return View("_navigationMenu", new NavigationMenuModel());
        }
    }
}