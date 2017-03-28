using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.DTO;
using Services.Interfaces;

namespace Services.Implementation
{
    public class TestCaseService : DbServiceBase<TestCaseDto>, ITestCaseService
    {
        public TestCaseService(ITCTSUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<TestCaseDto> GetAllTestCases()
        {
            return UnitOfWork.TestCaseRepository.GetAllTestCases().Select(ConvertToDto);
        }

        public TestCaseDto GetTestCaseById(int id)
        {
            return ConvertToDto(UnitOfWork.TestCaseRepository.GetTestCaseById(id));
        }

        public void DeleteTestCase(int id)
        {
            UnitOfWork.TestCaseRepository.RemoveById(id);
            UnitOfWork.Save();
        }

        public void AddNew(TestCaseDto testCase)
        {
            UnitOfWork.TestCaseRepository.Add(ConvertFromDto(testCase));
            UnitOfWork.Save();
        }

        public void Update(TestCaseDto testCase)
        {
            UnitOfWork.TestCaseRepository.Update(ConvertFromDto(testCase));
            UnitOfWork.Save();
        }

        public override bool HasAny()
        {
            return UnitOfWork.TestCaseRepository.HasAny();
        }

        private static TestCaseDto ConvertToDto(TestCase testCase)
        {
            return new TestCaseDto
            {
                ID = testCase.ID,
                Title = testCase.Title,
                Description = testCase.Description,
                Status = testCase.Status,
                CreatedBy = testCase.CreatedBy.Login,
                CreatedByID = testCase.CreatedByID,
                DateCreated = testCase.DateCreated,
                RunBy = testCase.RunBy?.Login,
                RunByID = testCase.RunByID,
                BacklogItemID = testCase.BacklogItemID
            };
        }

        private static TestCase ConvertFromDto(TestCaseDto dtoTestCase)
        {
            return new TestCase
            {
                ID = dtoTestCase.ID,
                Title = dtoTestCase.Title,
                Description = dtoTestCase.Description,
                Status = dtoTestCase.Status,
                CreatedByID = dtoTestCase.CreatedByID,
                DateCreated = dtoTestCase.DateCreated,
                RunByID = dtoTestCase.RunByID,
                BacklogItemID = dtoTestCase.BacklogItemID
            };
        }
    }
}
