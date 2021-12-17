using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseLoginService : ILoginService
{
    public async Task AnonymousLogin()
    {
        var auth = FirebaseAuth.DefaultInstance;
        await auth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInAnonymouslyAsync was cancelled");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInAnonymouslyAsync encountered an error" + task.Exception);
                return;
            }

            var newUser = task.Result;
            Debug.LogFormat("User signed successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
 
    public async Task UserPasswordLogin(string email, string password)
    {
        var auth = FirebaseAuth.DefaultInstance;
        
        await auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was cancelled");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error" + task.Exception);
                return;
            }

            var newUser = task.Result;
            Debug.LogFormat("User signed successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

        });
        
    }

    public async Task NewUserPasswordLogin(string email, string password)
    {
        var auth = FirebaseAuth.DefaultInstance;
        
        await auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was cancelled");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error" + task.Exception);
                return;
            }

            var newUser = task.Result;
            Debug.LogFormat("User signed successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    public bool CheckExistingUser()
    {
        var user = FirebaseAuth.DefaultInstance.CurrentUser;
        return (user != null);
    }

    public string GetUserID()
    {
        return FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    }
}