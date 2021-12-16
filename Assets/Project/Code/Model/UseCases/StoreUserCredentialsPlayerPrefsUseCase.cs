using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class StoreUserCredentialsPlayerPrefsUseCase
{
    public void Do(string email, string password)
    {
        var passwordEncryptor = new PasswordEncryptor();
        var encryptedPassword = passwordEncryptor.XOREncryptDecrypt(password);
        
        PlayerPrefs.SetString("EMAIL",email);
        PlayerPrefs.SetString("PASSWORD",encryptedPassword);
    }
}