using System.Collections;
using System.Collections.Generic;
using System.Text;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class SettingsMenuView : ViewBase
{

    private SettingsMenuViewModel _settingsMenuViewModel;
    [SerializeField] private float transitionTime;
    [SerializeField] private Button settingsButton;

    [SerializeField] private Button loginButton;

    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    [SerializeField] private Toggle notificationsCheckbox;
    [SerializeField] private Toggle soundCheckbox;
    
    public void SetViewModel(SettingsMenuViewModel settingsMenuViewModel)
    {
        _settingsMenuViewModel = settingsMenuViewModel;
      
        _settingsMenuViewModel.Show.Subscribe((show) =>
        {
            if (!show)
            {
                gameObject.GetComponent<RectTransform>().DOLocalMoveX(1440,
                    transitionTime);
                return;

            }
            gameObject
                .transform
                .DOLocalMoveX(0,
                    transitionTime);
        }).AddTo(_disposables);
      
        _settingsMenuViewModel.SettingsButtonEnabled.Subscribe((buttonEnabled) =>
        {
            settingsButton.interactable = buttonEnabled;

        }).AddTo(_disposables);

        
        _settingsMenuViewModel.CleanInputFields.Subscribe((_) =>
        {
            emailInputField.text = "";
            passwordInputField.text = "";
        });

        _settingsMenuViewModel.NotificationsCheckboxValue.Subscribe((value) =>
        {
            notificationsCheckbox.isOn = value;
        });
        
        _settingsMenuViewModel.SoundCheckboxValue.Subscribe((value) =>
        {
            soundCheckbox.isOn = value;
        });
        
        loginButton.onClick.AddListener(() =>
        {
            var userPass = new List<string> {emailInputField.text, passwordInputField.text};
            _settingsMenuViewModel.LoginButtonPressed.Execute(userPass);
            _settingsMenuViewModel.NotificationsCheckboxPressed.Execute(notificationsCheckbox.isOn);
            _settingsMenuViewModel.SoundCheckboxPressed.Execute(soundCheckbox.isOn);

        });

        notificationsCheckbox.onValueChanged.AddListener((_) =>
        {
            _settingsMenuViewModel.NotificationsCheckboxPressed.Execute(notificationsCheckbox.isOn);
        });

        soundCheckbox.onValueChanged.AddListener((_) =>
        {
            _settingsMenuViewModel.SoundCheckboxPressed.Execute(soundCheckbox.isOn);
        });


    }  
}