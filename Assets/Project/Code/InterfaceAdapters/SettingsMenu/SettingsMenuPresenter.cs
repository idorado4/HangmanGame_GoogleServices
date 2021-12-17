using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class SettingsMenuPresenter : PresenterBase
{
    private IEventDispatcherService _eventDispatcher;
    private readonly SettingsMenuViewModel _settingsMenuViewModel;
    public SettingsMenuPresenter(SettingsMenuViewModel settingsMenuViewModel)
    {
        _settingsMenuViewModel = settingsMenuViewModel;
        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcherService>();
        _eventDispatcher.Subscribe<UserData>(OnUserOptionsDataRecieved);
    }

    public void OnUserOptionsDataRecieved(UserData data)
    {
        _settingsMenuViewModel.NotificationsCheckboxValue.Value = data.Notifications;
        _settingsMenuViewModel.SoundCheckboxValue.Value = data.Sound;
    }
}
