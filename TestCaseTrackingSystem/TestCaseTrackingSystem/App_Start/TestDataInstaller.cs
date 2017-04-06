using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Implementation;
using DataAccess.Repositories.Interfaces;

namespace TestCaseStorage.App_Start
{
    public static class TestDataInstaller
    {
        private const int MaxUsersCount = 20;
        private const int MaxBacklogItemsCount = 30;
        private const int MaxTestCasesCount = 200;

        private static readonly Random RandomUser = new Random();
        private static readonly Random RandomBacklogItem = new Random();
        private static readonly Random RandomEnum = new Random();

        private const string TestBacklogItemTitlePattern = "Test_BacklogItemN{0}";
        private const string TestBacklogItemDescriptionPattern = "Test_BacklogItemDescriptionN{0}";

        private const string TestUserLoginPattern = "Test_LoginN{0}";
        private const string TestUserFirstNamePattern = "Test_FirstNameN{0}";
        private const string TestUserLastNamePattern = "Test_LastNameN{0}";
        private const string TestUserSkypePattern = "Test_SkypeN{0}";
        private const string TestUserEmailPattern = "Test_EmailN{0}";
        private const string TestUserPassword = "iware";

        private const string TestTestCaseTitle = "Test_TestCaseN{0}";
        private const string TestTestCaseDescription = "Test_TestCaseDescriptionN{0}";
        private const string TestTestCaseTag = "Test_TestCaseTagN{0}";

        public static void Install()
        {
            var enableTestData = Convert.ToBoolean(ConfigurationManager.AppSettings["enableTestData"]);

            var unitOfWork = new TCTSUnitOfWork(new TCTSDataContext());

            if (!enableTestData || unitOfWork.BacklogItemRepository.GetBacklogItemByTitle(string.Format(TestBacklogItemTitlePattern, MaxBacklogItemsCount)) != null) return;

            InstallUsers(unitOfWork);
            InstallBacklogItems(unitOfWork);
            InstallTestCases(unitOfWork);
        }

        private static void InstallBacklogItems(ITCTSUnitOfWork unitOfWork)
        {
            var backlogItems = Enumerable.Range(1, MaxBacklogItemsCount).Select(a => new BacklogItem
            {
                Title = string.Format(TestBacklogItemTitlePattern, a),
                Description = string.Format(TestBacklogItemDescriptionPattern, a),
                AssignedToID = GetRandomUserId(unitOfWork),
                DateCreated = DateTime.Now,
                Type = GetRandomEnum<BacklogItemType>(),
                Priority = GetRandomEnum<BacklogItemPriority>(),
                Severity = GetRandomEnum<BacklogItemSeverity>(),
                CreatedByID = GetRandomUserId(unitOfWork)
            });

            unitOfWork.BacklogItemRepository.AddRange(backlogItems);
            unitOfWork.Save();
        }
        
        private static void InstallUsers(ITCTSUnitOfWork unitOfWork)
        {
            var users = Enumerable.Range(1, MaxUsersCount).Select(a => new User
            {
                Login = string.Format(TestUserLoginPattern, a),
                Password = TestUserPassword,
                Role = GetRandomEnum<UserRole>(),
                Position = GetRandomEnum<Position>(),
                FirstName = string.Format(TestUserFirstNamePattern, a),
                LastName = string.Format(TestUserLastNamePattern, a),
                Email = string.Format(TestUserEmailPattern, a),
                Skype = string.Format(TestUserSkypePattern, a),
                CreatedDate = DateTime.Now
            });

            unitOfWork.UserRepository.AddRange(users);
            unitOfWork.Save();
        }

        private static void InstallTestCases(ITCTSUnitOfWork unitOfWork)
        {
            var testCases = Enumerable.Range(1, MaxTestCasesCount).Select(a => new TestCase
            {
                Title = string.Format(TestTestCaseTitle, a),
                Description = string.Format(TestTestCaseDescription, a),
                Tag = string.Format(TestTestCaseTag, a),
                Status = GetRandomEnum<TestCaseStatus>(),
                CreatedByID = GetTesterRandomUserId(unitOfWork),
                DateCreated = DateTime.Now,
                AssignedToID = GetTesterRandomUserId(unitOfWork),
                BacklogItemID = GetRandomBacklogItemId(unitOfWork)
            });

            unitOfWork.TestCaseRepository.AddRange(testCases);
            unitOfWork.Save();
        }

        private static TEnum GetRandomEnum<TEnum>()
        {
            var values = new List<TEnum>(Enum.GetValues(typeof(TEnum)).Cast<TEnum>());
            return values[RandomEnum.Next(0, values.Count)];
        }

        private static int GetRandomUserId(ITCTSUnitOfWork unitOfWork)
        {
            return unitOfWork.UserRepository.GetUserByLogin(string.Format(TestUserLoginPattern, RandomUser.Next(1, MaxUsersCount))).ID;
        }

        private static int GetTesterRandomUserId(ITCTSUnitOfWork unitOfWork)
        {
            var testerIds = unitOfWork.UserRepository.GetAllUsers().Where(t => t.Role == UserRole.QA).Select(t => t.ID).ToArray();

            return testerIds[RandomUser.Next(0, testerIds.Length)];
        }

        private static int GetRandomBacklogItemId(ITCTSUnitOfWork unitOfWork)
        {
            return unitOfWork.BacklogItemRepository.GetBacklogItemByTitle(string.Format(TestBacklogItemTitlePattern, RandomBacklogItem.Next(1, MaxUsersCount))).ID;
        }
    }
}