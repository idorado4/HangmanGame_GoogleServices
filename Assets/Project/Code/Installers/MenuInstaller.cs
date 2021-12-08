using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuInstaller : MonoBehaviour
{

    [SerializeField] private NavigationBarView _navigationBarView;
    [SerializeField] private HomeMenuView _homeMenuView;
    [SerializeField] private SettingsMenuView _settingsMenuView;
    
    
    private void Awake()
    {
        var navigationBarView = _navigationBarView;
        var homeMenuView = _homeMenuView;
        var settingsMenuView = _settingsMenuView;
        
        var navigationBarViewModel = new NavigationBarViewModel();
        var homeMenuViewModel = new HomeMenuViewModel();
        var settingsMenuViewModel = new SettingsMenuViewModel();
        
        navigationBarView.SetViewModel(navigationBarViewModel);
        homeMenuView.SetViewModel(homeMenuViewModel);
        settingsMenuView.SetViewModel(settingsMenuViewModel);

        new NavigationBarController(navigationBarViewModel, homeMenuViewModel, settingsMenuViewModel);

    }
}
