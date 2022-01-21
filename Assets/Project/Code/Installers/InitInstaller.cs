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
    private UserLoginAndUserDataUseCase userLoginAndUserDataUseCase;
    private InitializePushNotificationsUseCase initializePushNotificationsUseCase;
    private LoadSceneUseCase loadSceneUseCase;
    private InitializeAdsUseCase initializeAdsUseCase;

    private void Awake()
    {
        var eventDispatcher = new EventDispatcher();
        //Service Locator
        var serviceLocator = ServiceLocator.Instance;
        serviceLocator.RegisterService<ILoginService>(new FirebaseLoginService());
        serviceLocator.RegisterService<IDatabaseService>(new FirestoreDatabaseService());
        serviceLocator.RegisterService<INotificationsService>(new FirebaseCloudMessagingService());
        serviceLocator.RegisterService<IUserDataAccessService>(new UserRepository());
        serviceLocator.RegisterService<IAdsService>(new GoogleAdmobService());
        serviceLocator.RegisterService<IAnalyticsService>(new FirestoreAnalyticsService());
        serviceLocator.RegisterService<ILocalRankingService>(new LocalRankingRepository());
        serviceLocator.RegisterService<IRankingDataService>(new FirestoreRealtimeDatabaseService());
        serviceLocator.RegisterService<IEventDispatcherService>(new EventDispatcher());


        userLoginAndUserDataUseCase = new UserLoginAndUserDataUseCase();

        initializePushNotificationsUseCase = new InitializePushNotificationsUseCase();

        initializeAdsUseCase = new InitializeAdsUseCase();

        loadSceneUseCase = new LoadSceneUseCase();
    }

    private async void Start()
    {
        //CHECK DE USER Y LOGIN RESEPECTIVAMENTE
        await userLoginAndUserDataUseCase.Do();
        
        //INICIALIZO LAS NOTIFICACIONES QUE DEPENDEN DE LOS DATOS DEL PLAYER
        initializePushNotificationsUseCase.Do();
        
        //INICIALIZO LOS ANUNCIOS
        initializeAdsUseCase.Do();

        //CAMBIO DE ESCENA
        loadSceneUseCase.Do();
    }
}