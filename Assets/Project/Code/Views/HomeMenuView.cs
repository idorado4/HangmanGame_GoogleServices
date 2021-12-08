using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuView : ViewBase
{
    private HomeMenuViewModel _homeMenuViewModel;

    public void SetViewModel(HomeMenuViewModel homeMenuViewModel)
    {
        _homeMenuViewModel = homeMenuViewModel;
    }
    
}
