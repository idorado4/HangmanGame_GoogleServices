using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UniRx;

public class PopUpLoginController : ControllerBase
{
    private PopUpLoginViewModel _popUpLoginViewModel;
    
    public void SetViewModel(PopUpLoginViewModel popUpLoginViewModel)
    {
        _popUpLoginViewModel = popUpLoginViewModel;
        
        _popUpLoginViewModel.OnProfileButtonPressed.Subscribe((_) =>
        {
            _popUpLoginViewModel.ShowPanel.Value = true;
        });
    }

}
