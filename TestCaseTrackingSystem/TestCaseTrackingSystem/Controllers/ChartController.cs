using System.Web.Mvc;
using TestCaseStorage.Models.Chart;
using Services.Implementation;
using DataAccess.Repositories.Implementation;
using DataAccess;
using Services.Interfaces;
using System.Linq;
using DataAccess.Entities;
using Services.DTO;
using System;

namespace TestCaseStorage.Controllers
{
    [Authorize]
    public class ChartController : Controller
    {
        private ITestCaseService TestCaseService { get; }

        public ChartController()
        {
            TestCaseService = new TestCaseService(new TCTSUnitOfWork(new TCTSDataContext()));
        }

        [HttpGet]
        public ActionResult TestersStatisticsChart(TestCaseStatus status = TestCaseStatus.InProgress)
        {
            var chartModel = new ChartModel
            {
                YLabel = GetStatusYLabel(status),
                Guid = "chart",
                Type = ChartType.Bar,
                Labels = TestCaseService.GetTestersStatistics().Select(t => t.TesterName).Aggregate((a, b) => string.Format("'{0}'", a) + ", " + string.Format("'{0}'", b)),
                Values = TestCaseService.GetTestersStatistics().Select(t => GetStatusValue(status, t)).Aggregate((a, b) => string.Format("{0}", a) + ", " + string.Format("{0}", b))
            };

            return PartialView("_chart", chartModel);
        }

        private string GetStatusValue(TestCaseStatus status, TestersStatisticsDto test)
        {
            switch (status)
            {
                case TestCaseStatus.Failed:
                    return test.TestsFailed.ToString();
                case TestCaseStatus.InProgress:
                    return test.TestsInProgress.ToString();
                case TestCaseStatus.Pased:
                    return test.TestsPassed.ToString();
                default:
                    return test.TestsNotStarted.ToString();
            }
        }

        private string GetStatusYLabel(TestCaseStatus status)
        {
            switch (status)
            {
                case TestCaseStatus.Failed:
                    return "Тестов провалено";
                case TestCaseStatus.InProgress:
                    return "Тестов в процессе";
                case TestCaseStatus.Pased:
                    return "Тестов пройдено";
                default:
                    return "Тестов не начато";
            }
        }
    }
}