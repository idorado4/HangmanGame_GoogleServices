using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnalyticsService
{
    void LevelStartEvent(int level);
    void NewChanceEvent(bool value);
    void ShowAdEvent();
    
}
