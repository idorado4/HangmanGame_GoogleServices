using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IUserPasswordLoginUseCase
{
    void Do(string email, string password);
}
