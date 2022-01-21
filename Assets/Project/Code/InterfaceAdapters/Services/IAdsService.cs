using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public interface IAdsService
{
    void CreateRewardedAd();
    void LoadAd();
    void ShowAd();
    bool RewardObtained();
}
