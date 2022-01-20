using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTER : MonoBehaviour
{
  public void TEST()
  {
      ServiceLocator.Instance.GetService<IRankingDataService>().UpdateRankingData(1000, "10:00");
  }
}
