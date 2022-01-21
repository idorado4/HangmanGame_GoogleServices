using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameViewModel : ViewModelBase
{

    public readonly ReactiveProperty<bool> Show;
    public readonly ReactiveCommand OnExitButtonPressed;
    
    public GameViewModel()
    {
        Show = new ReactiveProperty<bool>(false).AddTo(_disposables);
        OnExitButtonPressed = new ReactiveCommand().AddTo(_disposables);
    }
}
