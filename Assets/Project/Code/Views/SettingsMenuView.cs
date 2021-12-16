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
        
        loginButton.onClick.AddListener(() =>
        {
            var userPass = new List<string>();
            
            userPass.Add(emailInputField.text);
            
            var passwordEncryptor = new PasswordEncryptor();
            var encryptedPass = passwordEncryptor.XOREncryptDecrypt(passwordInputField.text);
            userPass.Add(encryptedPass);
            
            _settingsMenuViewModel.LoginButtonPressed.Execute(userPass);
        });

       


    }  
}