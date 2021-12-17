using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NewUserPasswordLoginUseCase : IUserPasswordLoginUseCase
{

    public async void Do(string email, string password)
    {
        await ServiceLocator.Instance.GetService<ILoginService>().NewUserPasswordLogin(email, password);
        await ServiceLocator.Instance.GetService<IDatabaseService>().CreateUserData();
    }
}
