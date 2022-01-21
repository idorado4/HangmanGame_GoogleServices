using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RankingMenuController : ControllerBase
{
    private RankingMenuViewModel _rankingMenuViewModel;
   

    public void SetViewModel(RankingMenuViewModel rankingMenuViewModel)
    {
        _rankingMenuViewModel = rankingMenuViewModel;

        _rankingMenuViewModel.OnRankingButtonPressed.Subscribe((_) =>
        {
            var getRankingDataUseCase = new GetRankingDataUseCase();
        });
    }
}
