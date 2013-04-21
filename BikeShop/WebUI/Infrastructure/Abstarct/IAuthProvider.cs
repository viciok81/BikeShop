using System;

namespace WebUI.Infrastructure.Abstarct
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}
