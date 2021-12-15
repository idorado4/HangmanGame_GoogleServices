using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class UserLoginAndInitializeDataUseCase 
{
    public async Task Do()
    {
        var loginService = ServiceLocator.Instance.GetService<ILoginService>();
        //Debug.Log("Voy a checkear si hay user");
       
        if (!loginService.CheckExistingUser())
        {
            //LOGIN ANONIMO
            var anonymousLoginUseCase = new AnonymousLoginUseCase();
            await anonymousLoginUseCase.Do();

            //INIT INFO FIRESTORE
            var initializeUserDataUseCase = new InitializeUserDataUseCase();
            await initializeUserDataUseCase.Do();

            //INIT PLAYERPREF
            var createUserDataPlayerPrefsUseCase = new CreateUserDataPlayerPrefsUseCase();
            createUserDataPlayerPrefsUseCase.Do();
        }
        else
        {
            var getUserDataUseCase = new GetUserDataUseCase();
            await getUserDataUseCase.Do();
            Debug.Log("hecho el get user data de la dbb");
        }
    }
}