using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeUsernameUseCaseUseCase : IChangeUsernameUseCase
{
    public async Task Do(string newUsername)
    {
        await ServiceLocator.Instance.GetService<IDatabaseService>().UpdateUserData(newUsername);
    }
}
