using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Code.Web;
using Code.Web.HangmanApi;
using Code.Web.HangmanApi.Request;
using Code.Web.HangmanApi.Response;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class HangmanGame : MonoBehaviour
{
    [SerializeField] private List<Button> _guessLetterButton;
    private List<bool> interactableStates;
    [SerializeField] private TMP_Text _word;
    [SerializeField] private TMP_Text _points;
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _tries;
    
    private HomeMenuViewModel _homeMenuViewModel;
    private NavigationBarViewModel _navigationBarViewModel;
    private GameViewModel _gameViewModel;


    [Header("POPUP LOSE AD")] 
    [SerializeField] private Button exitGameGeneral;
    [SerializeField] private GameObject _popUpParent;

    [Header("POPUP LOSE AD")] [SerializeField]
    private GameObject _popUpLoseAd;

    [SerializeField] private Button _viewAdButton;
    [SerializeField] private Button _exitAdButton;

    [Header("POPUP LOSE")] [SerializeField]
    private GameObject _popUpLose;

    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _finalPointsText;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _retryButton;

    [Header("POPUP WIN")] [SerializeField] private GameObject _popUpWin;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitWinButton;


    [HideInInspector] public bool playing;
    [HideInInspector] public bool canShowAd;
    private bool adRewarded;
    private bool continuedPlaying;
    
    private float time;
    private int wordsStrike;
    private int acumPoints;
    private int tries;
    private string solution;

    private string _token;
    private StringBuilder _correctLetters;
    private StringBuilder _incorrectLetters;
    private HangmanClient _hangmanClient;

    private ShowAdUseCase _showAdUseCase;
    private LoadAdUseCase _loadAdUseCase;

    private void Awake()
    {
        _hangmanClient = new HangmanClient();
        _correctLetters = new StringBuilder();
        _incorrectLetters = new StringBuilder();

        for (int i = 0; i < _guessLetterButton.Count; i++)
        {
            LetterButton letterButton = _guessLetterButton[i].GetComponent<LetterButton>();
            Button button = _guessLetterButton[i];
            _guessLetterButton[i].onClick.AddListener(() => { GuessLetter(letterButton.GetLetter(), button); });
        }

        time = 0.0f;
        wordsStrike = 0;
        acumPoints = 0;
        canShowAd = true;
        adRewarded = false;

        _loadAdUseCase = new LoadAdUseCase();
        _showAdUseCase = new ShowAdUseCase();

        _popUpParent.SetActive(false);
        _popUpLose.SetActive(false);
        _popUpWin.SetActive(false);
        _popUpLoseAd.SetActive(false);

        _viewAdButton.onClick.AddListener(() =>
        {
            _showAdUseCase.Do();
            canShowAd = false;
        });
        _exitAdButton.onClick.AddListener(ExitGame);

        _retryButton.onClick.AddListener(Restart);
        _exitButton.onClick.AddListener(ExitGame);

        _continueButton.onClick.AddListener(ContinuePlaying);
        _exitWinButton.onClick.AddListener(ExitGame);
        
        exitGameGeneral.onClick.AddListener(ExitGame);
    }

    public void SetViewModel(GameViewModel gameViewModel,
        HomeMenuViewModel homeMenuViewModel,
        NavigationBarViewModel navigationBarViewModel)
    {
        _gameViewModel = gameViewModel;
        _homeMenuViewModel = homeMenuViewModel;
        _navigationBarViewModel = navigationBarViewModel;
    }

    private void ExitGame()
    {
        gameObject.SetActive(false);
        _homeMenuViewModel.Hide.Value = false;
        _navigationBarViewModel.Hide.Value = false;
        _gameViewModel.Show.Value = false;
        
        _popUpParent.SetActive(false);
        _popUpLose.SetActive(false);
        _popUpWin.SetActive(false);
        _popUpLoseAd.SetActive(false);
        
        time = 0.0f;
        wordsStrike = 0;
        acumPoints = 0;
        canShowAd = true;
        adRewarded = false;
        playing = false;
        continuedPlaying = false;
        
        for (int i = 0; i < _guessLetterButton.Count; i++)
        {
            _guessLetterButton[i].interactable = true;
            _guessLetterButton[i].image.color = Color.white;
        }
        
    }

    private async void Start()
    {
        //await StartGame();
    }

    private void Update()
    {
        if (playing)
        {
            time += Time.deltaTime;
            _time.text = $"{time}";
        }

        _tries.text = $"{tries}";

        var adsService = ServiceLocator.Instance.GetService<IAdsService>();
        adRewarded = adsService.RewardObtained();
        Debug.Log(adRewarded);
        if (adRewarded)
        {
            AdShowed();
        }
    }

    private void AdShowed()
    {
        if (continuedPlaying) return;
        Debug.Log("AdSowed call");
        _popUpLoseAd.SetActive(false);
        _popUpParent.SetActive(false);
        playing = true;
        tries = 5;
        continuedPlaying = true;
        for (int i = 0; i < _guessLetterButton.Count; i++)
        {
            _guessLetterButton[i].interactable = interactableStates[i];
        }
    }

    public async Task StartGame()
    {
        var response = await _hangmanClient
            .StartGame<NewGameResponse>(EndPoints.NewGame);
        UpdateToken(response.token);
        _word.SetText(AddSpacesBetweenLetters(response.hangman));
        tries = 5;
        GetSolution();
        _loadAdUseCase.Do();
        playing = true;
        Debug.Log("start hangman");
    }

    private void UpdateToken(string token)
    {
        _token = token;
    }

    private static string AddSpacesBetweenLetters(string word)
    {
        return string.Join(" ", word.ToCharArray());
    }

    private async void GuessLetter(string letter, Button letterButton)
    {
        if (string.IsNullOrEmpty(letter))
        {
            Debug.LogError("Input text is null");
            return;
        }

        if (letter.Length > 1)
        {
            Debug.LogError("Only 1 letter");
            return;
        }

        var response = await
            _hangmanClient.GuessLetter<GuessLetterResponse>
                (EndPoints.GuessLetter, _token, letter);

        UpdateToken(response.token);
        SetGuessResponse(response, letter, letterButton);

        if (IsCompleted(response.hangman))
        {
            wordsStrike++;
            acumPoints += wordsStrike * 100;
            _points.text = $"{acumPoints}";

            for (int i = 0; i < _guessLetterButton.Count; i++)
            {
                _guessLetterButton[i].interactable = false;
            }

            _popUpParent.SetActive(true);
            _popUpWin.SetActive(true);
            playing = false;
            Debug.Log("Complete");
        }
    }

    private void SetGuessResponse(GuessLetterResponse response, string letter, Button letterButton)
    {
        if (response.correct)
        {
            //LETRA CORRECTA
            _correctLetters.Append($" {letter}");
            letterButton.interactable = false;
            letterButton.image.color = Color.green;
        }
        else
        {
            //LETRA INCORRECTA
            _incorrectLetters.Append($" {letter}");
            letterButton.interactable = false;
            letterButton.image.color = Color.red;
            tries--;
        }

        if (tries == 0)
        {
            //Show popup
            _popUpParent.SetActive(true);
            if (canShowAd)
            {
                _popUpLoseAd.SetActive(true);
                interactableStates = new List<bool>();
                for (int i = 0; i < _guessLetterButton.Count; i++)
                {
                    interactableStates.Add(_guessLetterButton[i].interactable);
                }
            }
            else
            {
                _popUpLose.SetActive(true);
            }

            //apagar botones
            for (int i = 0; i < _guessLetterButton.Count; i++)
            {
                _guessLetterButton[i].interactable = false;
            }

            playing = false;
            _word.text = solution;
        }

        _word.SetText(AddSpacesBetweenLetters(response.hangman));
    }

    private async void GetSolution()
    {
        var response =
            await _hangmanClient
                .GetSolution<GetSolutionResponse>(EndPoints.GetSolution,
                    _token);

        solution = response.solution;
        Debug.Log(response.solution);
        UpdateToken(response.token);
    }

    private bool IsCompleted(string hangman)
    {
        const string secretCharacter = "_";
        return !hangman.Contains(secretCharacter);
    }

    private async void Restart()
    {
        await StartGame();
        for (int i = 0; i < _guessLetterButton.Count; i++)
        {
            _guessLetterButton[i].interactable = true;
            _guessLetterButton[i].image.color = Color.white;
        }

        time = 0.0f;
        wordsStrike = 0;
        acumPoints = 0;
        canShowAd = true;
        playing = true;
        continuedPlaying = false;

        _points.text = $"{acumPoints}";
        
        _popUpLose.SetActive(false);
        _popUpWin.SetActive(false);
        _popUpLoseAd.SetActive(false);
        _popUpParent.SetActive(false);
        
    }

    void ContinuePlaying()
    {
        for (int i = 0; i < _guessLetterButton.Count; i++)
        {
            _guessLetterButton[i].interactable = true;
            _guessLetterButton[i].image.color = Color.white;
        }

        playing = true;
        _popUpParent.SetActive(false);
        _popUpWin.SetActive(false);
        StartGame();
    }
}