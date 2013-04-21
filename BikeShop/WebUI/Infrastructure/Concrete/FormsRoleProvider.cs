using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Security;

namespace WebUI.Infrastructure.Concrete
{
    public sealed class FormsRoleProvider : RoleProvider
    {
        private string admin = ConfigurationManager.AppSettings["AdminEmail"];
        private readonly List<string> roles = new List<string>{"admin", "user"};

        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == admin && roleName == "admin") return true;
            if (roleName == "user" && username != admin) return true;
            return false;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        private string _applicationName;
        public override string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        } 
        
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return roles.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == admin)
            {
                return new string[] { "admin" };
            }
            return new string[] { "user" };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return roles.Any(x => x == roleName);
        }
   }
}