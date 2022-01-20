using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRankingDataUseCase : IGetRankingDataUseCase
{
    public void Do()
    {
        ServiceLocator.Instance.GetService<IRankingDataService>().GetRankingData();
    }
}
