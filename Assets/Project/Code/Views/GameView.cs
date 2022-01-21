using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Web;
using TMPro;
using UnityEngine;
using UniRx;

public class GameView : ViewBase
{
    private GameViewModel _gameViewModel;
    private HomeMenuViewModel _homeMenuViewModel;
    private NavigationBarViewModel _navigationBarViewModel;


    [SerializeField] private HangmanGame _hangmanGame;


    public void SetViewModel(
        GameViewModel gameViewModel,
        HomeMenuViewModel homeMenuViewModel,
        NavigationBarViewModel navigationBarViewModel)
    {
        _gameViewModel = gameViewModel;
        _homeMenuViewModel = homeMenuViewModel;
        _navigationBarViewModel = navigationBarViewModel;

        _gameViewModel
            .Show
            .Subscribe((value) =>
            {
                gameObject.SetActive(value);
                if (value)
                {
                    _hangmanGame.StartGame();
                    /*_hangmanGame.playing = true;
                    _hangmanGame.canShowAd = true;*/
                }
            })
            .AddTo(_disposables);
    }
}