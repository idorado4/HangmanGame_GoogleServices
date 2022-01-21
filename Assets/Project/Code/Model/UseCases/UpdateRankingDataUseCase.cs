using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateRankingDataUseCase : IUpdateRankingDataUseCase
{

    public void Do(int score, string time)
    {
        ServiceLocator.Instance.GetService<IRankingDataService>().UpdateRankingData(score, time);
    }
  
}
