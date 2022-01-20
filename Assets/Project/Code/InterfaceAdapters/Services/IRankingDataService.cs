using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public interface IRankingDataService
{
    Task GetRankingData();
    void UpdateRankingData(int score, string time);

}
