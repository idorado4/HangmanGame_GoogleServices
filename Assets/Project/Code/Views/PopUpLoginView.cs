using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PopUpLoginView : ViewBase
{
    private PopUpLoginViewModel _popUpLoginViewModel;
    private NavigationBarViewModel _navigationBarViewModel;
    
    [SerializeField] private Button popUpBackButton;
    [SerializeField] private Button popUpLoginButton;
    [SerializeField] private RectTransform popUpLoginPanel;

    public void SetViewModel(PopUpLoginViewModel popUpLoginViewModel, NavigationBarViewModel navigationBarViewModel)
    {
        _popUpLoginViewModel = popUpLoginViewModel;
        _navigationBarViewModel = navigationBarViewModel;
        
        _popUpLoginViewModel
            .ShowPanel
            .Subscribe((showPanel) =>
            {
                gameObject.SetActive(showPanel);
            }).AddTo(_disposables);
        
        popUpBackButton.onClick.AddListener(() =>
        {       
            _popUpLoginViewModel.OnBackButtonPressed.Execute();
            _navigationBarViewModel.EnableButtons.Execute();
        });
        
        popUpLoginButton.onClick.AddListener(() =>
        {
            _popUpLoginViewModel.OnLoginButtonPressed.Execute();
        });
    }
}