using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RankingMenuView : ViewBase
{
    private RankingMenuViewModel _rankingMenuViewModel;
    private NavigationBarViewModel _navigationBarViewModel;

    [SerializeField] private float transitionTime;
    [SerializeField] private Button rankingButton;
    [SerializeField] private GameObject RankingItemType1;
    [SerializeField] private GameObject RankingItemType2;
    [SerializeField] private RectTransform RankingItemsParent;

    private bool rankingSetted = false;

    public void SetViewModel(RankingMenuViewModel rankingMenuViewModel,
        NavigationBarViewModel navigationBarViewModel)
    {
        _rankingMenuViewModel = rankingMenuViewModel;
        _navigationBarViewModel = navigationBarViewModel;

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

        _navigationBarViewModel.OnRankingButtonPressed.Subscribe((_) =>
        {
            if (rankingSetted) return;

            rankingSetted = true;
            var ranking = ServiceLocator.Instance.GetService<ILocalRankingService>().GetLocalRanking();

            for (int i = 0; i < ranking.Count; i++)
            {
                if (i % 2 == 0)
                {
                    var rankingItem = Instantiate(RankingItemType1, Vector3.zero, Quaternion.identity,
                        RankingItemsParent);
                    rankingItem.GetComponent<RankingItemView>().SetData(ranking[i]);
                }
                else 
                {
                    var rankingItem = Instantiate(RankingItemType2, Vector3.zero, Quaternion.identity,
                        RankingItemsParent);
                    rankingItem.GetComponent<RankingItemView>().SetData(ranking[i]);
                }
            }
        }).AddTo(_disposables);
    }

    public void UpdateRankingItems()
    {
        rankingSetted = false;

        _navigationBarViewModel.OnRankingButtonPressed.Execute();
    }
}