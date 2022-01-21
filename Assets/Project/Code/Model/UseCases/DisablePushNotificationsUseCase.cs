using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePushNotificationsUseCase 
{
    public void Do()
    { 
        ServiceLocator.Instance.GetService<INotificationsService>().DisableNotifications();
    }
}
