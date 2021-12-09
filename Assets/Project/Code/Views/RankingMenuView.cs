using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RankingMenuView : ViewBase
{
    private RankingMenuViewModel _rankingMenuViewModel;
    [SerializeField] private float transitionTime;
    [SerializeField] private Button rankingButton;

   
    public void SetViewModel(RankingMenuViewModel rankingMenuViewModel)
    {
        _rankingMenuViewModel = rankingMenuViewModel;
      
        _rankingMenuViewModel.Show.Subscribe((show) =>
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

        _rankingMenuViewModel.RankingButtonEnabled.Subscribe((buttonEnabled) =>
        {
            rankingButton.interactable = buttonEnabled;

        }).AddTo(_disposables);
    }  
}
