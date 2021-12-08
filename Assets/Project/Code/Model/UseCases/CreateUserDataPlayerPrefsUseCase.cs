using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

public class CreateUserDataPlayerPrefsUseCase
{
    public void Do()
    {
        if (!PlayerPrefs.HasKey("USERID"))
        {
            var loginService = ServiceLocator.Instance.GetService<ILoginService>();
            PlayerPrefs.SetString("USERID", loginService.GetUserID());
            Debug.Log("Creado playerpref con USERID:" + loginService.GetUserID());
        }
    }
}