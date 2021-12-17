using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeUsernameUseCase : IChangeUsernameUseCase
{
    public void Do(string newUsername)
    {
        ServiceLocator.Instance.GetService<IDatabaseService>().UpdateUsername(newUsername);
    }
}
