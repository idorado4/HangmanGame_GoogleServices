using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class SettingsMenuView : ViewBase
{

   private SettingsMenuViewModel _settingsMenuViewModel;
   [SerializeField] private float transitionTime;
   [SerializeField] private Button settingsButton;

   
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
      
      _settingsMenuViewModel.ButtonEnabled.Subscribe((buttonEnabled) =>
      {
         settingsButton.interactable = buttonEnabled;

      }).AddTo(_disposables);
   }  
}
