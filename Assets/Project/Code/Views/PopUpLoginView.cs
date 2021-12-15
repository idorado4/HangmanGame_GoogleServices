using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PopUpLoginView : ViewBase
{
    private PopUpLoginViewModel _popUpLoginViewModel;
    private NavigationBarViewModel _navigationBarViewModel;
    
    [SerializeField] private Button popUpBackButton;
    [SerializeField] private Button popUpLoginButton;

    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;

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
            var user_pass  = new List<string>{usernameInputField.text, passwordInputField.text};
            _popUpLoginViewModel.OnLoginButtonPressed.Execute(user_pass);
        });
    }
}