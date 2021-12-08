using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface ILoginService
{
    Task AnonymousLogin();
    Task UserPasswordLogin();
    Task NewUserPasswordLogin(string email, string password);
    bool CheckExistingUser();
    string GetUserID();
}
