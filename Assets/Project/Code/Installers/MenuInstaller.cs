using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MenuInstaller : MonoBehaviour
{

    [SerializeField] private NavigationBarView _navigationBarView;
    
    [SerializeField] private HomeMenuView _homeMenuView;
    [SerializeField] private RankingMenuView _rankingMenuView;
    [SerializeField] private SettingsMenuView _settingsMenuView;
    
    [SerializeField] private PopUpProfileView _popUpProfileView;
    [SerializeField] private GameView _gameView;
    
    [SerializeField] private HangmanGame _hangmanGame;
    private InitGameUseCase initGameUseCase;
    private void Awake()
    {
        //ViewModels
        var navigationBarViewModel = new NavigationBarViewModel();
        var homeMenuViewModel = new HomeMenuViewModel();
        var settingsMenuViewModel = new SettingsMenuViewModel();
        var rankingMenuViewModel = new RankingMenuViewModel();
        var popUpProfileViewModel = new PopUpProfileViewModel();
        var gameViewModel = new GameViewModel();

        _navigationBarView.SetViewModel(navigationBarViewModel);
        _homeMenuView.SetViewModel(homeMenuViewModel, popUpProfileViewModel, navigationBarViewModel, gameViewModel);
        _settingsMenuView.SetViewModel(settingsMenuViewModel);
        _rankingMenuView.SetViewModel(rankingMenuViewModel, navigationBarViewModel);
        _popUpProfileView.SetViewModel(popUpProfileViewModel, navigationBarViewModel);
        _gameView.SetViewModel(gameViewModel, homeMenuViewModel, navigationBarViewModel);
        
        //Controllers
        var homeMenuController = new HomeMenuController();
        var popUpProfileController = new PopUpProfileController();
        var settingsMenuController = new SettingsMenuController();
        var rankingMenuController = new RankingMenuController();
        var gameController = new GameController();

        popUpProfileController.SetViewModel(popUpProfileViewModel, homeMenuViewModel);
        homeMenuController.SetViewModel(homeMenuViewModel,gameViewModel, navigationBarViewModel);
        settingsMenuController.SetViewModel(settingsMenuViewModel);
        gameController.SetViewModel(gameViewModel, homeMenuViewModel);
        
        new NavigationBarController(navigationBarViewModel, homeMenuViewModel, settingsMenuViewModel, rankingMenuViewModel);

        //Presenters
        new SettingsMenuPresenter(settingsMenuViewModel);
        new PopUpProfilePresenter(popUpProfileViewModel);
       
        var getRankingDataUseCase = new GetRankingDataUseCase();
        getRankingDataUseCase.Do();
        
        initGameUseCase = new InitGameUseCase();
        _hangmanGame.SetViewModel(gameViewModel, homeMenuViewModel, navigationBarViewModel);
    }

    private async void Start()
    {
        //await initGameUseCase.Do(_hangmanGame);
    }
}
