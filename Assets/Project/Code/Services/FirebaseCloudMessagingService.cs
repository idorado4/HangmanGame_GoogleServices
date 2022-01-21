using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Messaging;
using UnityEngine;

public class FirebaseCloudMessagingService : INotificationsService
{
    public void EnableNotifications()
    {
        FirebaseMessaging.TokenReceived += OnTokenReceived;
        FirebaseMessaging.MessageReceived += OnMessageReceived;
        Debug.Log("Notificaciones activadas");
    }

    public void DisableNotifications()
    {
        FirebaseMessaging.TokenReceived -= OnTokenReceived;
        FirebaseMessaging.MessageReceived -= OnMessageReceived;
        Debug.Log("Notificaciones desactivadas");
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