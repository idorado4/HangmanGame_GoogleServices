using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GetUserDataUseCase : IGetUserDataUseCase
{
    public async Task Do()
    {
        await ServiceLocator.Instance.GetService<IDatabaseService>().GetUserData();
    }
}