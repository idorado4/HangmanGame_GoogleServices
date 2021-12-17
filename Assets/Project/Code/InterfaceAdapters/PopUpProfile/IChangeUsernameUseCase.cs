using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IChangeUsernameUseCase
{
    void Do(string newUsername);
}
