using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuPresenter : PresenterBase
{

    //private readonly HomeMenuViewModel;
    private EventDispatcher _eventDispatcher;
    
    
    
    public HomeMenuPresenter(EventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
        _eventDispatcher.Subscribe<UserData>(OnUsernameChanged);
    }

    public void OnUsernameChanged(UserData data)
    {
        //CAMBIAR EL NOMBRE DEL USERNAME DEL VIEWMODEL (reactive property)
        //_homeMenuViewModel.string.value = data.username;
    }
}
