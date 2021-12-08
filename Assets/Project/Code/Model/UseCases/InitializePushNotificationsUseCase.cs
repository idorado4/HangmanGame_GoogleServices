using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InitializePushNotificationsUseCase
{
    public void Do()
    { 
        ServiceLocator.Instance.GetService<INotificationsService>().ActivateNotifications();
    }
}
