using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PopUpLoginView : ViewBase
{
    private PopUpLoginViewModel _popUpLoginViewModel;
    [SerializeField] private Button popUpBackButton;
    [SerializeField] private Button popUpLoginButton;
    [SerializeField] private RectTransform popUpLoginPanel;

    public void SetViewModel(PopUpLoginViewModel popUpLoginViewModel)
    {
        _popUpLoginViewModel = popUpLoginViewModel;
        
        _popUpLoginViewModel
            .ShowPanel
            .Subscribe((showPanel) =>
            {
                gameObject.SetActive(showPanel);
            }).AddTo(_disposables);
        
        /*popUpBackButton.onClick.AddListener(() =>
        {       
            _popUpLoginViewModel.OnBackButtonPressed.Execute();
        });
        
        popUpLoginButton.onClick.AddListener(() =>
        {
            _popUpLoginViewModel.OnLoginButtonPressed.Execute();
        });

        popUpLoginViewModel.ShowPanel.Subscribe((show) =>
        {
            popUpLoginPanel.gameObject.SetActive(show);
        });*/
    }
}