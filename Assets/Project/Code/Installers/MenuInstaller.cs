using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuInstaller : MonoBehaviour
{

    [SerializeField] private NavigationBarView _navigationBarView;
    
    [SerializeField] private HomeMenuView _homeMenuView;
    [SerializeField] private RankingMenuView _rankingMenuView;
    [SerializeField] private SettingsMenuView _settingsMenuView;
    
    [SerializeField] private PopUpProfileView _popUpProfileView;
    
    
    private void Awake()
    {
        var navigationBarViewModel = new NavigationBarViewModel();
        var homeMenuViewModel = new HomeMenuViewModel();
        var settingsMenuViewModel = new SettingsMenuViewModel();
        var rankingMenuViewModel = new RankingMenuViewModel();
        var popUpProfileViewModel = new PopUpProfileViewModel();

        _navigationBarView.SetViewModel(navigationBarViewModel);
        _homeMenuView.SetViewModel(homeMenuViewModel, popUpProfileViewModel, navigationBarViewModel);
        _settingsMenuView.SetViewModel(settingsMenuViewModel);
        _rankingMenuView.SetViewModel(rankingMenuViewModel);
        _popUpProfileView.SetViewModel(popUpProfileViewModel, navigationBarViewModel);
        
        var homeMenuController = new HomeMenuController();
        var popUpProfileController = new PopUpProfileController();
        
        popUpProfileController.SetViewModel(popUpProfileViewModel, homeMenuViewModel);
        homeMenuController.SetViewModel(homeMenuViewModel);
        

        new NavigationBarController(navigationBarViewModel, homeMenuViewModel, settingsMenuViewModel, rankingMenuViewModel);

    }
}
