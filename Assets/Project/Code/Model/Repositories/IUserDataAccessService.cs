public interface IUserDataAccessService
{
    UserData GetLocalUser();
    void SetLocalUser(UserData userEntity);
    void SetUsername(string username);
    void SetNotifications(bool value);
    void SetSound(bool value);
}