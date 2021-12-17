using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpProfilePresenter : PresenterBase
{
    private IEventDispatcherService _eventDispatcher;
    private readonly PopUpProfileViewModel _popUpProfileViewModel;
    public PopUpProfilePresenter(PopUpProfileViewModel popUpProfileViewModel)
    {
        _popUpProfileViewModel = popUpProfileViewModel;
        _eventDispatcher = ServiceLocator.Instance.GetService<IEventDispatcherService>();
        _eventDispatcher.Subscribe<UserData>(OnUserUsernameDataRecieved);
    }

    public void OnUserUsernameDataRecieved(UserData data)
    {
        _popUpProfileViewModel.Username.Value = data.Username;
    }
    
}
