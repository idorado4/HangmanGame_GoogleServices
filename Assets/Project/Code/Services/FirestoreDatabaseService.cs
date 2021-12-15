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
    public async Task InitializeUserData()
    {
        var db = FirebaseFirestore.DefaultInstance;
        var auth = FirebaseAuth.DefaultInstance;
        
        //GENERAMOS LA INFORMACIÓN DEL USUARIO INCIAL
        var docRef = db
            .Collection("users")
            .Document(auth.CurrentUser.UserId);
        
        //TODO Generar un nombre aleatorio, (MIRAR SI ESTÁ DUPLICADO EN LA BDD?)
        //COGER LOS 5 PRIMEROS CARACTERES DEL AUTH.USER
        await docRef
            .SetAsync(new UserData
            {
                Username = "DefaultName",
                Sound = true,
                Notifications = true
            })
            .ContinueWithOnMainThread(task =>
            {
                Debug.Log("info added in firestore database");
            });
    }

    public async Task CreateUserData()
    {
        var db = FirebaseFirestore.DefaultInstance;

        //GENERAMOS LA INFORMACIÓN DEL USUARIO INCIAL
        var docRef = db
            .Collection("users")
            .Document(ServiceLocator.Instance.GetService<ILoginService>().GetUserID());
        
        //TODO Generar un nombre aleatorio, (MIRAR SI ESTÁ DUPLICADO EN LA BDD?)
        //COGER LOS 5 PRIMEROS CARACTERES DEL AUTH.USER
        await docRef
            .SetAsync(new UserData
            {
                Username = "DefaultName",
                Sound = true,
                Notifications = true
            })
            .ContinueWithOnMainThread(task =>
            {
                Debug.Log("info added in firestore database");
            });
    }

    public async Task UpdateUserData()
    {
    }

    public async Task GetUserData()
    {
        var db = FirebaseFirestore.DefaultInstance;

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
                          +" // Notis:" + userData.Notifications );
            });
    }
}