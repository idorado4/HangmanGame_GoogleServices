using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PopUpProfileController : ControllerBase
{
    private PopUpProfileViewModel _popUpProfileViewModel;
    private HomeMenuViewModel _homeMenuViewModel;
    
    public void SetViewModel(PopUpProfileViewModel popUpProfileViewModel, HomeMenuViewModel homeMenuViewModel)
    {
        _popUpProfileViewModel = popUpProfileViewModel;
        _homeMenuViewModel = homeMenuViewModel;
        
        _popUpProfileViewModel.OnProfileButtonPressed.Subscribe((_) =>
        {
            _popUpProfileViewModel.ShowPanel.Value = true;
            
        });

        _popUpProfileViewModel.OnBackButtonPressed.Subscribe((_) =>
        {
            _popUpProfileViewModel.ShowPanel.Value = false;
            _homeMenuViewModel.ProfileButtonEnabled.Value = true;
        });

        _popUpProfileViewModel.OnChangeUsernameButtonPressed.Subscribe((newUsername) =>
        {
            var changeUsernameUseCaseUseCase = new ChangeUsernameUseCase();
            changeUsernameUseCaseUseCase.Do(newUsername);
            _popUpProfileViewModel.Username.Value = newUsername;
            
        });
    }
}