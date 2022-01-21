using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UniRx;
public class GameController : ControllerBase
{
    private GameViewModel _gameViewModel;
    private HomeMenuViewModel _homeMenuViewModel;

    public void SetViewModel(GameViewModel gameViewModel,
        HomeMenuViewModel homeMenuViewModel)
    {
        _gameViewModel = gameViewModel;
        _homeMenuViewModel = homeMenuViewModel;

        _gameViewModel.OnExitButtonPressed.Subscribe((_) =>
        {
            _gameViewModel.Show.Value = false;
            homeMenuViewModel.Show.Value = true;
        });
    }
}
