using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class NavigationBarController : ControllerBase
{
    private readonly NavigationBarViewModel _navigationBarViewModel;
    private readonly HomeMenuViewModel _homeMenuViewModel;
    private readonly SettingsMenuViewModel _settingsMenuViewModel;

    public NavigationBarController(NavigationBarViewModel navigationBarViewModel,
                                    HomeMenuViewModel homeMenuViewModel,
                                    SettingsMenuViewModel settingsMenuViewModel)
    {
        _navigationBarViewModel = navigationBarViewModel;
        _homeMenuViewModel = homeMenuViewModel;
        _settingsMenuViewModel = settingsMenuViewModel;

        _navigationBarViewModel.OnSettingsButtonPressed.Subscribe((_) =>
        {
            _settingsMenuViewModel.Show.Value = true;
        });




    }
    
}
