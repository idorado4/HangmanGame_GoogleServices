using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateRankingDataUseCase
{
    void Do(int score, string time);
}
