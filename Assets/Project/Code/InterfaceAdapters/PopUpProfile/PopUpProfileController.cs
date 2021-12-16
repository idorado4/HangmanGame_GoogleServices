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
            /*var userPasswordLoginUseCase = new UserPasswordLoginUseCase();
            userPasswordLoginUseCase.Do(user_pass[0], user_pass[1]);
            Debug.Log(user_pass[0] +"  "+ user_pass[1]);*/
            //use case de login password
            
            //use case de update username pasando el newUsername
            var changeUsernameUseCaseUseCase = new ChangeUsernameUseCaseUseCase();
            changeUsernameUseCaseUseCase.Do(newUsername);
        });
    }
}