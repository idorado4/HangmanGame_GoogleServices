using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class HomeMenuController : ControllerBase
{
    private HomeMenuViewModel _homeMenuViewModel;
    private PopUpLoginViewModel _popUpLoginViewModel;

    public void SetViewModel(HomeMenuViewModel homeMenuViewModel,PopUpLoginViewModel popUpLoginViewModel)
    {
        _homeMenuViewModel = homeMenuViewModel;
        _popUpLoginViewModel = popUpLoginViewModel;

        _homeMenuViewModel.OnProfileButtonPressed.Subscribe((_) =>
        {
            _homeMenuViewModel.ProfileButtonEnabled.Value = false;
        });
    }
}
