using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTER : MonoBehaviour
{
  public void TEST()
  {
      ServiceLocator.Instance.GetService<IRankingDataService>().UpdateRankingData(2000, "10:00");
  }
}
