using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class InitializeAdsUseCase : IInitializeAdsUseCase
{
    public void Do()
    {
        ServiceLocator.Instance.GetService<IAdsService>().CreateRewardedAd();
        ServiceLocator.Instance.GetService<IAdsService>().LoadAd();
    }
}