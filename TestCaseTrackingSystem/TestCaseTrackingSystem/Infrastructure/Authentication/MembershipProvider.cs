using System;
using System.Web.Security;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Implementation;

namespace TestCaseStorage.Infrastructure.Authentication
{
    public class TCTSMembershipProvider : MembershipProvider
    {
        private ITCTSUnitOfWork UnitOfWork { get; }

        public TCTSMembershipProvider()
        {
           UnitOfWork = new TCTSUnitOfWork(new TCTSDataContext());
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var user = GetUser(username, false);

            if (user == null)
            {
                var newUser = new User
                {
                    Login = username,
                    Password = password,
                    Email = email,
                    CreatedDate = DateTime.Now,
                    Locked = false,
                    FirstName = username,
                    LastName = username
                };

                UnitOfWork.UserRepository.Add(newUser);
                UnitOfWork.Save();

                status = MembershipCreateStatus.Success;

                return GetUser(username, false);
            }

            status = MembershipCreateStatus.DuplicateUserName;

            return null;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = UnitOfWork.UserRepository.GetByLogin(username);

            return user != null && user.Password.Equals(password);
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = UnitOfWork.UserRepository.GetByLogin(username);

            return user != null 
                ? new MembershipUser("TCTSMembershipProvider", user.Login, user.ID, user.Email, string.Empty, string.Empty, true, false, user.CreatedDate, user.LastLogin ?? DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue) 
                : null;
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordRetrieval { get; }
        public override bool EnablePasswordReset { get; }
        public override bool RequiresQuestionAndAnswer { get; }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get; }
        public override int PasswordAttemptWindow { get; }
        public override bool RequiresUniqueEmail { get; }
        public override MembershipPasswordFormat PasswordFormat { get; }
        public override int MinRequiredPasswordLength { get; }
        public override int MinRequiredNonAlphanumericCharacters { get; }
        public override string PasswordStrengthRegularExpression { get; }
    }
}