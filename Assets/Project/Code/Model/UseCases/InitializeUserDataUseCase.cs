using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InitializeUserDataUseCase : IInitializeUserDataUseCase
{
    public async Task Do()
    {
        await ServiceLocator.Instance.GetService<IDatabaseService>().CreateUserData();  
    }
}