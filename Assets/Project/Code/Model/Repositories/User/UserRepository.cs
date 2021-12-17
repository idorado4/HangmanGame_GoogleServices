public class UserRepository : IUserDataAccessService
{
    private UserData _userEntity;

    public UserData GetLocalUser()
    {
        return _userEntity;
    }

    public void SetLocalUser(UserData userEntity)
    {
        _userEntity = userEntity;
    }

    public void SetUsername(string username)
    {
        _userEntity.Username = username;
    }

    public void SetNotifications(bool value)
    {
        _userEntity.Notifications = value;
    }

    public void SetSound(bool value)
    {
        _userEntity.Sound = value;
    }
}