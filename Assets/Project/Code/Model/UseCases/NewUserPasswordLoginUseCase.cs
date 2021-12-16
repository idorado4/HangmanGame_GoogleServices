using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserPasswordLoginUseCase : IUserPasswordLoginUseCase
{

    public async void Do(string email, string password)
    {
        await ServiceLocator.Instance.GetService<ILoginService>().UserPasswordLogin(email, password);
        await ServiceLocator.Instance.GetService<IDatabaseService>().CreateUserData();
    }
}
