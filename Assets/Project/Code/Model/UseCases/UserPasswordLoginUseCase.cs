using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UserPasswordLoginUseCase : IUserPasswordLoginUseCase
{
    public async Task Do()
    {
        await ServiceLocator.Instance.GetService<ILoginService>().UserPasswordLogin();
    }
}
