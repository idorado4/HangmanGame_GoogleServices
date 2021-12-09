using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RankingMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    public readonly ReactiveProperty<bool> ButtonEnabled;
    
    public RankingMenuViewModel()
    {
        Show = new ReactiveProperty<bool>(false).AddTo(_disposables);
        ButtonEnabled = new ReactiveProperty<bool>(true).AddTo(_disposables);
    }
}
