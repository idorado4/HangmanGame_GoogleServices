using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HomeMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    public readonly ReactiveProperty<bool> Hide;
    public readonly ReactiveProperty<bool> HomeButtonEnabled;
    public readonly ReactiveProperty<bool> ProfileButtonEnabled;
    public readonly ReactiveCommand OnProfileButtonPressed;
    public readonly ReactiveCommand OnPlayButtonPressed;
    
    public HomeMenuViewModel()
    {
        Show = new ReactiveProperty<bool>(true).AddTo(_disposables);
        Hide = new ReactiveProperty<bool>(false).AddTo(_disposables);
        HomeButtonEnabled = new ReactiveProperty<bool>(false).AddTo(_disposables);
        ProfileButtonEnabled = new ReactiveProperty<bool>(true).AddTo(_disposables);
        OnProfileButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnPlayButtonPressed = new ReactiveCommand().AddTo(_disposables);

    }
}
