using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IChangeUsernameUseCase
{
    Task Do(string newUsername);
}
