using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UniRx;

public class PopUpLoginController : ControllerBase
{
    private PopUpLoginViewModel _popUpLoginViewModel;
    private HomeMenuViewModel _homeMenuViewModel;
    
    public void SetViewModel(PopUpLoginViewModel popUpLoginViewModel, HomeMenuViewModel homeMenuViewModel)
    {
        _popUpLoginViewModel = popUpLoginViewModel;
        _homeMenuViewModel = homeMenuViewModel;
        
        _popUpLoginViewModel.OnProfileButtonPressed.Subscribe((_) =>
        {
            _popUpLoginViewModel.ShowPanel.Value = true;
            
        });

        _popUpLoginViewModel.OnBackButtonPressed.Subscribe((_) =>
        {
            _popUpLoginViewModel.ShowPanel.Value = false;
            _homeMenuViewModel.ProfileButtonEnabled.Value = true;
        });

        _popUpLoginViewModel.OnLoginButtonPressed.Subscribe((user_pass) =>
        {
            var userPasswordLoginUseCase = new UserPasswordLoginUseCase();
            userPasswordLoginUseCase.Do(user_pass[0], user_pass[1]);
            Debug.Log(user_pass[0] +"  "+ user_pass[1]);
            //use case de login password
        });
    }

}