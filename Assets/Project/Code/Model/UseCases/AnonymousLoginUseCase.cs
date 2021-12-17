using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AnonymousLoginUseCase : IAnonymousLoginUseCase
{
    public async Task Do()
    { 
        await ServiceLocator.Instance.GetService<ILoginService>().AnonymousLogin();
    }
}
