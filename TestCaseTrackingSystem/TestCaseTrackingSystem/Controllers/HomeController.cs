using DataAccess.Entities;
using System.Web.Mvc;
using TestCaseStorage.Models.Home;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index(TestCaseStatus testCaseStatus = TestCaseStatus.Pased)
        {
            return View("Index", new HomeModel { TestCaseStatus = testCaseStatus });
        }
    }
}