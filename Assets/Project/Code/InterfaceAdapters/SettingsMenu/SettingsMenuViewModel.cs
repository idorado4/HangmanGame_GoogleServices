using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    public readonly ReactiveProperty<bool> SettingsButtonEnabled;
    public readonly ReactiveCommand<List<string>> LoginButtonPressed;
    public readonly ReactiveCommand CleanInputFields;
    public readonly ReactiveProperty<string> Username;

    public SettingsMenuViewModel()
    {
        Show = new ReactiveProperty<bool>(false).AddTo(_disposables);
        Username = new ReactiveProperty<string>().AddTo(_disposables);
        SettingsButtonEnabled = new ReactiveProperty<bool>(true).AddTo(_disposables);
        LoginButtonPressed = new ReactiveCommand<List<string>>().AddTo(_disposables);
        CleanInputFields = new ReactiveCommand().AddTo(_disposables);
    }
    
    
}