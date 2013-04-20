﻿
using System.Web.Security;
using WebUI.Infrastructure.Abstarct;

namespace WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {

            bool result = FormsAuthentication.Authenticate(username, password);// Membership.ValidateUser(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username,false);
            }
            return result;
        }
    }
}