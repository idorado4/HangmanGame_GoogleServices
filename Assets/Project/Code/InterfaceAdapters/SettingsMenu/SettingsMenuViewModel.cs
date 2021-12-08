using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsMenuViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> Show;
    public SettingsMenuViewModel()
    {
        Show = new ReactiveProperty<bool>(false);
    }
    
    
}
