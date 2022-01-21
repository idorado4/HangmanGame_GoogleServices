using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdUseCase
{
    public void Do()
    {
        ServiceLocator.Instance.GetService<IAdsService>().ShowAd();
    }
}