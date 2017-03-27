using System.Web.Mvc;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}