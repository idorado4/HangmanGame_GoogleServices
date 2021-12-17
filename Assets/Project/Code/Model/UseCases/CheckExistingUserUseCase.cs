using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Firebase.Auth;
using UnityEngine;

public class CheckExistingUserUseCase 
{
    public async void Do(List<string> userPass)
    {
        string email= userPass[0];;
        string password = userPass[1];
        
        var auth = FirebaseAuth.DefaultInstance;
        var methods = await auth.FetchProvidersForEmailAsync(email);
        
        if (methods.Contains("password")) {
            Debug.Log("Email Existe");
          
            var userPasswordLoginUseCase = new UserPasswordLoginUseCase();
            userPasswordLoginUseCase.Do(email, password);
        }
        else
        {
            Debug.Log("Email NO Existe");
            var newUserPasswordLoginUseCase = new NewUserPasswordLoginUseCase();
            newUserPasswordLoginUseCase.Do(email, password);
            
            var storeUserCredentialsPlayerPrefsUseCase = new StoreUserCredentialsPlayerPrefsUseCase();
            storeUserCredentialsPlayerPrefsUseCase.Do(email, password);
        }
        
        var eventDispatcher = ServiceLocator.Instance.GetService<IDatabaseService>();
        await eventDispatcher.GetUserData();
    }
}
