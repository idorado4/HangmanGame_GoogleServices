using System.Collections;
using System.Collections.Generic;
using Firebase.Firestore;
using UnityEngine;

[FirestoreData]
public class UserData
{
    [FirestoreProperty] public string Username { get; set; }
    [FirestoreProperty] public bool Sound { get; set; }
    [FirestoreProperty] public bool Notifications { get; set; }

    public UserData(){} 
    
}