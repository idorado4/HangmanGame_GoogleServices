using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    
    public readonly ReactiveProperty<bool> SettingsButtonEnabled;
    
    public readonly ReactiveProperty<bool> NotificationsCheckboxValue;
    public readonly ReactiveProperty<bool> SoundCheckboxValue;
    
    public readonly ReactiveCommand<List<string>> LoginButtonPressed;
    public readonly ReactiveCommand<bool> NotificationsCheckboxPressed;
    public readonly ReactiveCommand<bool> SoundCheckboxPressed;
    
    public readonly ReactiveCommand CleanInputFields;

    public SettingsMenuViewModel()
    {
        var userDataRepo = ServiceLocator.Instance.GetService<IUserDataAccessService>();
        
        Show = new ReactiveProperty<bool>(false).AddTo(_disposables);
        
        SettingsButtonEnabled = new ReactiveProperty<bool>(true).AddTo(_disposables);
        
        NotificationsCheckboxValue= new ReactiveProperty<bool>(userDataRepo.GetLocalUser().Notifications).AddTo(_disposables);
        SoundCheckboxValue = new ReactiveProperty<bool>(userDataRepo.GetLocalUser().Sound).AddTo(_disposables);
        
        LoginButtonPressed = new ReactiveCommand<List<string>>().AddTo(_disposables);
        NotificationsCheckboxPressed = new ReactiveCommand<bool>().AddTo(_disposables);
        SoundCheckboxPressed = new ReactiveCommand<bool>().AddTo(_disposables);
        
        CleanInputFields = new ReactiveCommand().AddTo(_disposables);
    }
    
    
}