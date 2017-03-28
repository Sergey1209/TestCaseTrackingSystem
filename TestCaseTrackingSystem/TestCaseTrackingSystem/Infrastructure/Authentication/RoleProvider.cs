using System;
using System.Linq;
using DataAccess;
using DataAccess.Repositories.Implementation;
using DataAccess.Repositories.Interfaces;

namespace TestCaseStorage.Infrastructure.Authentication
{
    public class TCTSRoleProvider : System.Web.Security.RoleProvider
    {
        private IUserRepository UserRepository { get; }

        public TCTSRoleProvider()
        {
            UserRepository = new UserRepository(new TCTSDataContext()) ;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return GetRolesForUser(username).Contains(roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            return new[] { UserRepository.GetUserByLogin(username).Role.ToString()};
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}