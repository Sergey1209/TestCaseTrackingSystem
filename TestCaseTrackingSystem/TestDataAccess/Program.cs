using System;
using DataAccess;
using DataAccess.Repositories.Implementation;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new TCTSUnitOfWork(new TCTSDataContext()))
            {
                var testCases = unitOfWork.TestCaseRepository.GetAllBacklogItemTestCases(1);

                foreach (var testCase in testCases)
                {
                    Console.WriteLine($"Title - {testCase.Title}, Status - {testCase.Status.Name}");
                }
            }

            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }
}
