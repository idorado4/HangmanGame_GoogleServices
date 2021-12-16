using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ILoginService
{
    Task AnonymousLogin();
    Task UserPasswordLogin(string email, string password);
    Task NewUserPasswordLogin(string email, string password);
    bool CheckExistingUser();
    bool IsAnonymous();
    string GetUserID();
}
