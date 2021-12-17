using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PopUpProfileViewModel : ViewModelBase
{
    public readonly ReactiveProperty<bool> ShowPanel;
    public readonly ReactiveProperty<string> Username;
    public readonly ReactiveCommand OnBackButtonPressed;
    public readonly ReactiveCommand OnProfileButtonPressed;
    public readonly ReactiveCommand<string> OnChangeUsernameButtonPressed;

    public PopUpProfileViewModel()
    {
        ShowPanel = new ReactiveProperty<bool>(false).AddTo(_disposables);
        Username = new ReactiveProperty<string>(ServiceLocator.Instance.GetService<IUserDataAccessService>().GetLocalUser().Username).AddTo(_disposables);
        OnBackButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnProfileButtonPressed = new ReactiveCommand().AddTo(_disposables);
        OnChangeUsernameButtonPressed = new ReactiveCommand<string>().AddTo(_disposables);
    }
}
