using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class UserLoginAndUserDataUseCase 
{
    public async Task Do()
    {
        var loginService = ServiceLocator.Instance.GetService<ILoginService>();
       
        if (!loginService.CheckExistingUser())
        {
            //LOGIN ANONIMO
            var anonymousLoginUseCase = new AnonymousLoginUseCase();
            await anonymousLoginUseCase.Do();

            //INIT INFO FIRESTORE
            var initializeUserDataUseCase = new InitializeUserDataUseCase();
            await initializeUserDataUseCase.Do();
        }
        else
        {
            if (PlayerPrefs.HasKey("PASSWORD"))
            {
                var userPasswordLoginUseCase = new UserPasswordLoginUseCase();
                var passwordEncryptor = new PasswordEncryptor();
                var unencryptedPassword = passwordEncryptor.XOREncryptDecrypt(PlayerPrefs.GetString("PASSWORD"));
                userPasswordLoginUseCase.Do(PlayerPrefs.GetString("EMAIL"), unencryptedPassword);
            }
            var getUserDataUseCase = new GetUserDataUseCase();
            await getUserDataUseCase.Do();
            Debug.Log("hecho el get user data de la dbb");
        }
    }
}