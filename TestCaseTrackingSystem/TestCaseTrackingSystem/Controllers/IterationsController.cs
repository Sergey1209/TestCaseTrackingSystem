using System.Web.Mvc;

namespace TestCaseStorage.Controllers
{
    public class IterationsController : Controller
    {
        [HttpGet]
        public ViewResult List()
        {
            return View("List");
        }
    }
}