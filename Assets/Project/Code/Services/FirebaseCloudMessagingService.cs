using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Messaging;
using UnityEngine;

public class FirebaseCloudMessagingService : INotificationsService
{
    public void ActivateNotifications()
    {
        FirebaseMessaging.TokenReceived += OnTokenReceived;
        FirebaseMessaging.MessageReceived += OnMessageReceived;
    }

    private void OnTokenReceived(object sender, TokenReceivedEventArgs token)
    {
        Debug.Log("Received Registration Token: " + token.Token);
    }
    private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
    {
        Debug.Log("Received a new message from: " + e.Message.From);
    }

}