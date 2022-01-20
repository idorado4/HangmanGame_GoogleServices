using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTANALYTICS : MonoBehaviour
{
    public void ANALYTICS()
    {
        ServiceLocator.Instance.GetService<IAnalyticsService>().LevelStartEvent(1);
        ServiceLocator.Instance.GetService<IAnalyticsService>().NewChanceEvent(true);
        ServiceLocator.Instance.GetService<IAnalyticsService>().ShowAdEvent();
    }
}
