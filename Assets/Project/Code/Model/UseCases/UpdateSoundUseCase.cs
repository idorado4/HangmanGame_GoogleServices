using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSoundUseCase
{
    public void Do(bool value)
    {
        ServiceLocator.Instance.GetService<IUserDataAccessService>().SetSound(value);
        ServiceLocator.Instance.GetService<IDatabaseService>().UpdateSound(value);
    }
}
