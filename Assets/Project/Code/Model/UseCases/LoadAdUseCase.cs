using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAdUseCase
{
    public void Do()
    {
        ServiceLocator.Instance.GetService<IAdsService>().LoadAd();
    }
}