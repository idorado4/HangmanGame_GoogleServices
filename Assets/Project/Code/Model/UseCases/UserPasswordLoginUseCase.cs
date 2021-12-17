using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class UserPasswordLoginUseCase : IUserPasswordLoginUseCase
{
    public async void Do(string email, string password)
    {
        await ServiceLocator.Instance.GetService<ILoginService>().UserPasswordLogin(email, password);
        await ServiceLocator.Instance.GetService<IDatabaseService>().GetUserData();
    }
}

