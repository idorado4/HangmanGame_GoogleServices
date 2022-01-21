using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsMenuController : ControllerBase
{
    private SettingsMenuViewModel _settingsMenuViewModel;
    private EventDispatcher _eventDispatcher;
    public void SetViewModel (SettingsMenuViewModel settingsMenuViewModel)
    {
        _settingsMenuViewModel = settingsMenuViewModel;

        _settingsMenuViewModel
            .LoginButtonPressed
            .Subscribe(OnLoginButtonPressed)
            .AddTo(_disposables);

        _settingsMenuViewModel
            .NotificationsCheckboxPressed
            .Subscribe(OnNotificationsCheckboxPressed)
            .AddTo(_disposables);
        
        _settingsMenuViewModel
            .SoundCheckboxPressed
            .Subscribe(OnSoundCheckboxPressed)
            .AddTo(_disposables);
    }

    private void OnLoginButtonPressed(List<string> userPass)
    {
        var checkExistingUserUseCase = new CheckExistingUserUseCase();
        checkExistingUserUseCase.Do(userPass);

        _settingsMenuViewModel.CleanInputFields.Execute();
    }

    private void OnNotificationsCheckboxPressed(bool value)
    {
        var updateNotificationsUseCase = new UpdateNotificationsUseCase();
        updateNotificationsUseCase.Do(value);
        var disablePushNotificationsUseCase = new DisablePushNotificationsUseCase();
        disablePushNotificationsUseCase.Do();
    }

    private void OnSoundCheckboxPressed(bool value)
    {
        var updateSoundUseCase = new UpdateSoundUseCase();
        updateSoundUseCase.Do(value);
    }
}
