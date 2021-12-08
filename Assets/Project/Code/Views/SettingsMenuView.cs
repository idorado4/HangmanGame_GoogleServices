using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UniRx;
public class SettingsMenuView : ViewBase
{

   private SettingsMenuViewModel _settingsMenuViewModel;
   [SerializeField] private float transitionTime;
   
   public void SetViewModel(SettingsMenuViewModel settingsMenuViewModel)
   {
      _settingsMenuViewModel = settingsMenuViewModel;
      
      _settingsMenuViewModel.Show.Subscribe((show) =>
      {
         Debug.Log("Show reactive");
         if (show)
         {
            gameObject
               .transform
               .DOLocalMoveX(0,
                              transitionTime);

         }
      });
   }  
}
