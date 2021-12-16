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
        //Service Locator
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.RegisterService<ILoginService>(new FirebaseLoginService());
        serviceLocator.RegisterService<IDatabaseService>(new FirestoreDatabaseService());
        serviceLocator.RegisterService<INotificationsService>(new FirebaseCloudMessagingService());
        
        
        //INCIO LAS NOTIFICACIONES QUE VAN SIN DEPENDER DE LOS DEMÁS SERVICIOS
        var initializePushNotificationsUseCase = new InitializePushNotificationsUseCase();
        initializePushNotificationsUseCase.Do();
        
        //serviceLocator.GetService<INotificationsService>().

        //CHECK DE USER Y LOGIN RESEPECTIVAMENTE
        var userLoginAndUserDataUseCase = new UserLoginAndUserDataUseCase();
        await userLoginAndUserDataUseCase.Do();
        
        var loadSceneUseCase = new LoadSceneUseCase();
        loadSceneUseCase.Do();
    }
}