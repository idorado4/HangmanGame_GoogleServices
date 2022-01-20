using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class GoogleAdmobService : IAdsService
{
    private RewardedAd _rewardedAd;
    public void CreateRewardedAd()
    {
        //ESTE ES EL DE MUESTRA
        string rewardedAdId = "ca-app-pub-3940256099942544/5224354917";
        _rewardedAd = new RewardedAd(rewardedAdId);
        Handlers();
    }

    

    public void LoadAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        _rewardedAd.LoadAd(request);
    }

    public void ShowAd()
    {
        if (_rewardedAd.IsLoaded()) {
            _rewardedAd.Show();
        }
    }
    
    private void Handlers()
    {
        // Called when an ad request has successfully loaded.
        _rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        _rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        _rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        _rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        _rewardedAd.OnAdClosed += HandleRewardedAdClosed;

    }
    
   
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
            + args.LoadAdError);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
            + args.AdError);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        
        //CREA Y CARGA UN ANUNCIO NUEVO
        CreateRewardedAd();
        LoadAd();
        
    }
    

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
            + amount.ToString() + " " + type);
    }
}