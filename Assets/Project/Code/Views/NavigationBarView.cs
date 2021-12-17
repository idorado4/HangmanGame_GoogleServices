using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBarView : ViewBase
{
    private NavigationBarViewModel _navigationBarViewModel;

    [SerializeField] private Button homeButton;
    [SerializeField] private Button rankingButton;
    [SerializeField] private Button settingsButton;
    
    
    public void SetViewModel(NavigationBarViewModel navigationBarViewModel)
    {
        _navigationBarViewModel = navigationBarViewModel;
        
        homeButton.onClick.AddListener(() =>
        {
            _navigationBarViewModel.OnHomeButtonPressed.Execute();
        });
        
        rankingButton.onClick.AddListener(() =>
        {
            _navigationBarViewModel.OnRankingButtonPressed.Execute();
        });
        
        settingsButton.onClick.AddListener(() =>
        {
            _navigationBarViewModel.OnSettingsButtonPressed.Execute();
        });
    }
}
