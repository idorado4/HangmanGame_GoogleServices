using System.Collections;
using System.Collections.Generic;
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
      
        
      loginButton.onClick.AddListener(() =>
      {
         var user_pass  = new List<string>{emailInputField.text, passwordInputField.text};
         _settingsMenuViewModel.OnLoginButtonPressed.Execute(user_pass);
      });
   }  
}
