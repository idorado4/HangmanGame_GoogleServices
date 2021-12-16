using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    public readonly ReactiveProperty<bool> SettingsButtonEnabled;
    public readonly ReactiveCommand<List<string>> OnLoginButtonPressed;
    
    public SettingsMenuViewModel()
    {
        Show = new ReactiveProperty<bool>(false).AddTo(_disposables);
        SettingsButtonEnabled = new ReactiveProperty<bool>(true).AddTo(_disposables);
        OnLoginButtonPressed = new ReactiveCommand<List<string>>().AddTo(_disposables);
    }
    
    
}
