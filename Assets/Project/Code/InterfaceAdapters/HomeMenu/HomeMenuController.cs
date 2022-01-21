using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class HomeMenuController : ControllerBase
{
    private HomeMenuViewModel _homeMenuViewModel;
    private GameViewModel _gameViewModel;
    private NavigationBarViewModel _navigationBarViewModel;

    public void SetViewModel(HomeMenuViewModel homeMenuViewModel,
        GameViewModel gameViewModel,
        NavigationBarViewModel navigationBarViewModel)
    {
        _homeMenuViewModel = homeMenuViewModel;
        _gameViewModel = gameViewModel;
        _navigationBarViewModel = navigationBarViewModel;

        _homeMenuViewModel.OnProfileButtonPressed.Subscribe((_) =>
        {
            _homeMenuViewModel.ProfileButtonEnabled.Value = false;
        });
        
        _homeMenuViewModel.OnPlayButtonPressed.Subscribe((_) =>
        {
            _gameViewModel.Show.Value = true;
            homeMenuViewModel.Hide.Value = true;
            _navigationBarViewModel.Hide.Value = true;
        });
    }
}
