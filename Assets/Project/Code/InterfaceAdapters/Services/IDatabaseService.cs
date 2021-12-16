using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IDatabaseService
{
    Task InitializeUserData();
    Task CreateUserData();
    void UpdateUserData(string newUsername);
    Task GetUserData();
}