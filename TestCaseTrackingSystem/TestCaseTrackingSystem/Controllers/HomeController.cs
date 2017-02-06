using System.Web.Mvc;

namespace TestCaseStorage.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}