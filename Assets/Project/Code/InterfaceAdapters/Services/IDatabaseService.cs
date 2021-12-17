using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IDatabaseService
{
    Task CreateUserData();
    void UpdateUsername(string newUsername);
    void UpdateNotifications(bool value);
    void UpdateSound(bool value);
    Task GetUserData();
}