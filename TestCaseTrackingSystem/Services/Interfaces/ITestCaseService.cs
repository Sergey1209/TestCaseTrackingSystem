using System.Collections.Generic;
using Services.DTO;

namespace Services.Interfaces
{
    public interface ITestCaseService : IService<TestCaseDto>
    {
        IEnumerable<TestCaseDto> GetAllTestCases();
        IEnumerable<TestersStatisticsDto> GetTestersStatistics();
        TestCaseDto GetTestCaseById(int id);
        void DeleteTestCase(int id);
        void AddNew(TestCaseDto testCase);
        void Update(TestCaseDto testCase);
    }
}
