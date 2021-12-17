using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase.Messaging;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitInstaller : MonoBehaviour
{
    private async void Awake()
    {
        var eventDispatcher = new EventDispatcher();
        //Service Locator
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.RegisterService<ILoginService>(new FirebaseLoginService());
        serviceLocator.RegisterService<IDatabaseService>(new FirestoreDatabaseService());
        serviceLocator.RegisterService<INotificationsService>(new FirebaseCloudMessagingService());
        serviceLocator.RegisterService<IUserDataAccessService>(new UserRepository());
        serviceLocator.RegisterService<IEventDispatcherService>(new EventDispatcher());
        

        //CHECK DE USER Y LOGIN RESEPECTIVAMENTE
        var userLoginAndUserDataUseCase = new UserLoginAndUserDataUseCase();
        await userLoginAndUserDataUseCase.Do();
        
        //INCIO LAS NOTIFICACIONES QUE DEPENDEN DE LOS DATOS DEL PLAYER
        var initializePushNotificationsUseCase = new InitializePushNotificationsUseCase();
        initializePushNotificationsUseCase.Do();
        
        var loadSceneUseCase = new LoadSceneUseCase();
        loadSceneUseCase.Do();
    }
}