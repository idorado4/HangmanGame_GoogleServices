using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenuView : ViewBase
{
    private HomeMenuViewModel _homeMenuViewModel;
    private PopUpLoginViewModel _popUpLoginViewModel;
    [SerializeField] private float transitionTime;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button popUpProfileButton;

    public void SetViewModel(HomeMenuViewModel homeMenuViewModel, PopUpLoginViewModel popUpLoginViewModel)
    {
        _homeMenuViewModel = homeMenuViewModel;
        _popUpLoginViewModel = popUpLoginViewModel;

        _homeMenuViewModel
            .Show
            .Subscribe((show) =>
            {
                if (!show)
                {
                    gameObject.GetComponent<RectTransform>().DOLocalMoveX(1440,
                        transitionTime);
                    return;
                }

                gameObject.transform.DOLocalMoveX(0, transitionTime);
            })
            .AddTo(_disposables);

        _homeMenuViewModel
            .HomeButtonEnabled
            .Subscribe((buttonEnabled) =>
            {
                homeButton.interactable = buttonEnabled;

            }).AddTo(_disposables);

        _homeMenuViewModel
            .ProfileButtonEnabled
            .Subscribe((buttonEnabled) =>
            {
                popUpProfileButton.interactable = buttonEnabled;
            }).AddTo(_disposables);

        //Button
        popUpProfileButton
            .onClick
            .AddListener(() =>
            {
                _homeMenuViewModel.OnProfileButtonPressed.Execute();
                _popUpLoginViewModel.OnProfileButtonPressed.Execute();
            });
      

    }
    
}