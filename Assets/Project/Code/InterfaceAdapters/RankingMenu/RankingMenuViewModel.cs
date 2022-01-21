using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RankingMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    public readonly ReactiveProperty<bool> RankingButtonEnabled;
    public readonly ReactiveCommand OnRankingButtonPressed;
    
    public RankingMenuViewModel()
    {
        Show = new ReactiveProperty<bool>(false).AddTo(_disposables);
        RankingButtonEnabled = new ReactiveProperty<bool>(true).AddTo(_disposables);
        OnRankingButtonPressed = new ReactiveCommand().AddTo(_disposables);
    }
}
