using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;

public class FirestoreDatabaseService : IDatabaseService
{
    public async Task CreateUserData()
    {
        var db = FirebaseFirestore.DefaultInstance;
        var auth = FirebaseAuth.DefaultInstance;
        
        //GENERAMOS LA INFORMACIÓN DEL USUARIO INCIAL
        var docRef = db
            .Collection("users")
            .Document(auth.CurrentUser.UserId);
        
        //TODO Generar un nombre aleatorio, (MIRAR SI ESTÁ DUPLICADO EN LA BDD?)

        var newUserData = new UserData
        {
            Username = "DefaultName",
            Sound = true,
            Notifications = true
        };

        //COGER LOS 5 PRIMEROS CARACTERES DEL AUTH.USER
        await docRef
            .SetAsync(newUserData)
            .ContinueWithOnMainThread(task =>
            {
                Debug.Log("info added in firestore database");
                ServiceLocator.Instance.GetService<IUserDataAccessService>().SetLocalUser(newUserData);
            });
    }
    
    public async void UpdateUsername(string newUsername)
    {
        var db = FirebaseFirestore.DefaultInstance;
        
        var docRef = db.Collection("users")
            .Document(ServiceLocator.Instance.GetService<ILoginService>().GetUserID());

        await docRef.UpdateAsync("Username", newUsername);
    }

    public async void UpdateNotifications(bool value)
    {
        var db = FirebaseFirestore.DefaultInstance;
        
        var docRef = db.Collection("users")
            .Document(ServiceLocator.Instance.GetService<ILoginService>().GetUserID());

        await docRef.UpdateAsync("Notifications", value);
    }

    public async void UpdateSound(bool value)
    {
        var db = FirebaseFirestore.DefaultInstance;
        
        var docRef = db.Collection("users")
            .Document(ServiceLocator.Instance.GetService<ILoginService>().GetUserID());

        await docRef.UpdateAsync("Sound", value);
    }

    public async Task GetUserData()
    {
        var db = FirebaseFirestore.DefaultInstance;
        var eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcherService>();
        var userDataRepo = ServiceLocator.Instance.GetService<IUserDataAccessService>();
        
        var docRef = db.Collection("users")
            .Document(ServiceLocator.Instance.GetService<ILoginService>().GetUserID());

        await docRef
            .GetSnapshotAsync()
            .ContinueWithOnMainThread(task =>
            {
                
                var userDocument = task.Result;
                var userData = userDocument.ConvertTo<UserData>();
                
                Debug.Log($"COGIDO DE LA BASE DE DATOS:" 
                          +" //Username: " + userData.Username 
                          +" // Sound: " + userData.Sound
                          +" // Notis: " + userData.Notifications );
                
                userDataRepo.SetLocalUser(userData);
                eventDispatcher.Dispatch(userData);
            });
    }
}