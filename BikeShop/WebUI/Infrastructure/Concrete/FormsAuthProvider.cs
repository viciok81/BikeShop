using System.Web.Security;
using Domain.Abstract;
using WebUI.Infrastructure.Abstarct;
using System.Linq;
using System.Configuration;

namespace WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private string admin = ConfigurationManager.AppSettings["AdminEmail"];
        private IProductionRepository repository;

        public FormsAuthProvider(IProductionRepository _repository)
        {
            repository = _repository;
        }
        public bool Authenticate(string username, string password)
        {
            bool result = false;
            string role;
            role = username == admin ? "admin" : "user";
            var user = repository.Customers.FirstOrDefault(x => x.EmailAddress == username);
                if (user != null)
                {
                    result = StringUtils.IsValidPassword(password, user.PasswordSalt, user.PasswordHash);
                    if (result)
                    {
                        FormsAuthentication.SetAuthCookie(username, false);
                        if (!Roles.IsUserInRole(username, role)) Roles.AddUserToRole(username, role);
                    }
                }
            return result;
        }
    }
}