using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEditor.VersionControl;
using UnityEngine;

public class PopUpLoginViewModel : ViewModelBase
{
    public ReactiveProperty<bool> ShowPanel;
    public readonly ReactiveCommand OnBackButtonPressed;
    public readonly ReactiveCommand OnProfileButtonPressed;
    public readonly ReactiveCommand<List<string>> OnLoginButtonPressed;

    public PopUpLoginViewModel()
    {
        ShowPanel = new ReactiveProperty<bool>(false).AddTo(_disposables);
        OnProfileButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnBackButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnLoginButtonPressed = new ReactiveCommand<List<string>>().AddTo(_disposables);
    }
}
