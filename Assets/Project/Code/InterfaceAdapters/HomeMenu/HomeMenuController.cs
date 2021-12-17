using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class HomeMenuController : ControllerBase
{
    private HomeMenuViewModel _homeMenuViewModel;

    public void SetViewModel(HomeMenuViewModel homeMenuViewModel)
    {
        _homeMenuViewModel = homeMenuViewModel;

        _homeMenuViewModel.OnProfileButtonPressed.Subscribe((_) =>
        {
            _homeMenuViewModel.ProfileButtonEnabled.Value = false;
        });
    }
}
