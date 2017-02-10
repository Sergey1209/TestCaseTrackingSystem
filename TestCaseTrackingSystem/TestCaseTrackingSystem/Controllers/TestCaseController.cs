using System.Collections.Generic;
using System.Web.Mvc;
using TestCaseStorage.Models.TestCases;

namespace TestCaseStorage.Controllers
{
    public class TestCaseController : Controller
    {
        [HttpGet]
        public ViewResult List()
        {
            var testCases = new List<TestCase>();

            return View("List", testCases);
        }
    }
}