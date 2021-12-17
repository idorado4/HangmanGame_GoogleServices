using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UpdateNotificationsUseCase
{
    public void Do(bool value)
    {
        ServiceLocator.Instance.GetService<IUserDataAccessService>().SetNotifications(value);
        ServiceLocator.Instance.GetService<IDatabaseService>().UpdateNotifications(value);
    }
}
