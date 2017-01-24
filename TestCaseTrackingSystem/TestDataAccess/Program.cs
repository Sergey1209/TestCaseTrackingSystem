using System;
using System.Linq;
using DataAccess;
using DataAccess.Entities;
using System.Data.Entity;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestCaseDataContext())
            {
                CreateTestIteration(context);
                CreateTestBacklogItem(context);
                AddTestCasesToTestBacklogItem(context);

                var testCases = context.BacklogItems.Include(t => t.TestCases).First().TestCases;

                foreach (var testCase in testCases)
                {
                    Console.WriteLine($"Title - {testCase.Title}, Status - {testCase.Status.Name}, User Created - {testCase.CreatedBy.FirstName}, User Run - {testCase.RunBy?.FirstName}");
                }
            }

            Console.ReadKey();
        }

        private static void CreateTestIteration(TestCaseDataContext context)
        {
            var testIteration = new Iteration
            {
                Name = "Test Iteration",
                StartDate = new DateTime(2017, 1, 1),
                EndDate = new DateTime(2017, 1, 31)
            };

            if (!context.Iterations.Any(t => string.Equals(t.Name, testIteration.Name)))
            {
                context.Iterations.Add(testIteration);
                context.SaveChanges();
            }
        }

        private static void CreateTestBacklogItem(TestCaseDataContext context)
        {
            var testBacklogItem = new BacklogItem
            {
                Type = context.BacklogItemTypes.First(t => t.Type == "Story"),
                Title = "Test story",
                CreatedBy = context.Users.First(t => t.FirstName == "admin"),
                DateCreated = DateTime.Now
            };

            if (!context.BacklogItems.Any(t => string.Equals(t.Title, testBacklogItem.Title)))
            {
                context.BacklogItems.Add(testBacklogItem);
                context.SaveChanges();
            }
        }

        private static void AddTestCasesToTestBacklogItem(TestCaseDataContext context)
        {
            var testTestCase = new TestCase
            {
                Title = "Test test case",
                CreatedBy = context.Users.First(t => t.FirstName == "admin"),
                Status = context.TestCaseStatuses.First(t => t.Name == "Not Started"),
                DateCreated = DateTime.Now,
                BacklogItem = context.BacklogItems.First(t => t.Title == "Test story")
            };

            if (!context.TestCases.Any(t => string.Equals(t.Title, testTestCase.Title)))
            {
                context.TestCases.Add(testTestCase);
                context.SaveChanges();
            }
        }
    }
}
