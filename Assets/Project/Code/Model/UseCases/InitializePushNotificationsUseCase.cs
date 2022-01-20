using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InitializePushNotificationsUseCase
{
    public void Do()
    {
        var user = ServiceLocator.Instance.GetService<IUserDataAccessService>().GetLocalUser();
        if (user.Notifications){
            ServiceLocator.Instance.GetService<INotificationsService>().EnableNotifications();
            return;
        }
        ServiceLocator.Instance.GetService<INotificationsService>().DisableNotifications();
    }
}