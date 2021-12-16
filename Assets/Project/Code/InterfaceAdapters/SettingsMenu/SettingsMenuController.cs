using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsMenuController : ControllerBase
{
    private SettingsMenuViewModel _settingsMenuViewModel;
    public void SetViewModel (SettingsMenuViewModel settingsMenuViewModel)
    {
        _settingsMenuViewModel = settingsMenuViewModel;

        _settingsMenuViewModel
            .LoginButtonPressed
            .Subscribe(OnLoginButtonPressed).AddTo(_disposables);
    }

    private void OnLoginButtonPressed(List<string> userPass)
    {
        var userPasswordLoginUseCase = new NewUserPasswordLoginUseCase();
        userPasswordLoginUseCase.Do(userPass[0], userPass[1]);
        _settingsMenuViewModel.CleanInputFields.Execute();
        var storeUserCredentialsPlayerPrefsUseCase = new StoreUserCredentialsPlayerPrefsUseCase();
        storeUserCredentialsPlayerPrefsUseCase.Do(userPass[0], userPass[1]);
    }
    
    
}
