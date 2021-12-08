using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class NavigationBarViewModel : ViewModelBase
{
    public readonly ReactiveCommand OnHomeButtonPressed;
    public readonly ReactiveCommand OnRankingButtonPressed;
    public readonly ReactiveCommand OnSettingsButtonPressed;

    public NavigationBarViewModel()
    {
        OnHomeButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnRankingButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnSettingsButtonPressed = new ReactiveCommand().AddTo(_disposables);
    }
}
