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

        //Checking User and logging accordingly.
        //Creating/Getting the user data from Firestore
        //Creating PlayerPrefs
        if (!PlayerPrefs.HasKey("PASSWORD"))
        {
            var userLoginAndInitializeDataUseCase = new UserLoginAndInitializeDataUseCase();
            await userLoginAndInitializeDataUseCase.Do();
        }
        else
        {
            var userPasswordLoginUseCase = new UserPasswordLoginUseCase();
            await userPasswordLoginUseCase.Do();
        }

        var loadSceneUseCase = new LoadSceneUseCase();
        loadSceneUseCase.Do();
    }
}