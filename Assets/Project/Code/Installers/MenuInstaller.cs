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
    
    [SerializeField] private PopUpLoginView _popUpLoginView;
    
    
    
    private void Awake()
    {
        var navigationBarViewModel = new NavigationBarViewModel();
        var homeMenuViewModel = new HomeMenuViewModel();
        var settingsMenuViewModel = new SettingsMenuViewModel();
        var rankingMenuViewModel = new RankingMenuViewModel();
        var popUpLoginViewModel = new PopUpLoginViewModel();

        _navigationBarView.SetViewModel(navigationBarViewModel);
        _homeMenuView.SetViewModel(homeMenuViewModel, popUpLoginViewModel, navigationBarViewModel);
        _settingsMenuView.SetViewModel(settingsMenuViewModel);
        _rankingMenuView.SetViewModel(rankingMenuViewModel);
        _popUpLoginView.SetViewModel(popUpLoginViewModel, navigationBarViewModel);

        var homeMenuController = new HomeMenuController();
        var popUpLoginController = new PopUpLoginController();
        
        popUpLoginController.SetViewModel(popUpLoginViewModel, homeMenuViewModel);
        homeMenuController.SetViewModel(homeMenuViewModel);
        

        new NavigationBarController(navigationBarViewModel, homeMenuViewModel, settingsMenuViewModel, rankingMenuViewModel);

    }
}
