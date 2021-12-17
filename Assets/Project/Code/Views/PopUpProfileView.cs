using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PopUpProfileView : ViewBase
{

    private PopUpProfileViewModel _popUpProfileViewModel;
    private NavigationBarViewModel _navigationBarViewModel;

    [SerializeField] private Button backButton;
    [SerializeField] private Button changeUsernameButton;

    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_Text username;
    
    public void SetViewModel(PopUpProfileViewModel popUpProfileViewModel, NavigationBarViewModel navigationBarViewModel)
    {
        _popUpProfileViewModel = popUpProfileViewModel;
        _navigationBarViewModel = navigationBarViewModel;

        _popUpProfileViewModel.ShowPanel.Subscribe((showPanel) =>
        {
            gameObject.SetActive(showPanel);
        });

        _popUpProfileViewModel.Username.Subscribe((_username) =>
        {
            username.text = _username;
            usernameInputField.text = "";
        });
        
        backButton.onClick.AddListener(() =>
        {
            _popUpProfileViewModel.OnBackButtonPressed.Execute();
            _navigationBarViewModel.EnableButtons.Execute();
        });
        
        changeUsernameButton.onClick.AddListener(() =>
        {
            _popUpProfileViewModel.OnChangeUsernameButtonPressed.Execute(usernameInputField.text);
        });
        
    }

}