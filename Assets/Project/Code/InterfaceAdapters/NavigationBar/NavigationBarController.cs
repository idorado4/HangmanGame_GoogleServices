using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEditorInternal;
using UnityEngine;

public class NavigationBarController : ControllerBase
{
    private readonly NavigationBarViewModel _navigationBarViewModel;
    private readonly HomeMenuViewModel _homeMenuViewModel;
    private readonly SettingsMenuViewModel _settingsMenuViewModel;
    private readonly RankingMenuViewModel _rankingMenuViewModel;

    public NavigationBarController(NavigationBarViewModel navigationBarViewModel,
                                    HomeMenuViewModel homeMenuViewModel,
                                    SettingsMenuViewModel settingsMenuViewModel, 
                                    RankingMenuViewModel rankingMenuViewModel)
    {
        _navigationBarViewModel = navigationBarViewModel;
        _homeMenuViewModel = homeMenuViewModel;
        _settingsMenuViewModel = settingsMenuViewModel;
        _rankingMenuViewModel = rankingMenuViewModel;

        _navigationBarViewModel.OnHomeButtonPressed.Subscribe((_) =>
        {
            _homeMenuViewModel.Show.Value = true;
            _rankingMenuViewModel.Show.Value = false;
            _settingsMenuViewModel.Show.Value = false;  
            
            _homeMenuViewModel.HomeButtonEnabled.Value = false;
            _rankingMenuViewModel.ButtonEnabled.Value = true;
            _settingsMenuViewModel.ButtonEnabled.Value = true;
        });
        
        _navigationBarViewModel.OnRankingButtonPressed.Subscribe((_) =>
        {
            _homeMenuViewModel.Show.Value = false;
            _rankingMenuViewModel.Show.Value = true;
            _settingsMenuViewModel.Show.Value = false;
            
            _homeMenuViewModel.HomeButtonEnabled.Value = true;
            _rankingMenuViewModel.ButtonEnabled.Value = false;
            _settingsMenuViewModel.ButtonEnabled.Value = true;
        });
        
        _navigationBarViewModel.OnSettingsButtonPressed.Subscribe((_) =>
        {
            _homeMenuViewModel.Show.Value = false;
            _rankingMenuViewModel.Show.Value = false;
            _settingsMenuViewModel.Show.Value = true;
            
            _homeMenuViewModel.HomeButtonEnabled.Value = true;
            _rankingMenuViewModel.ButtonEnabled.Value = true;
            _settingsMenuViewModel.ButtonEnabled.Value = false;
        });
        
        
       




    }
    
}
