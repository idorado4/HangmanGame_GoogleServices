using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirestoreAnalyticsService : IAnalyticsService
{

    public void LevelStartEvent(int level)
    {
        // Log an event with an int parameter.
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(
                "level_start",
                "level",
                level
            );
    }

    public void NewChanceEvent(bool value)
    {
        int castedValue = value ? 1 : 0;
        // Log an event with an int parameter.
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(
                "level_start",
                "level",
                castedValue
            );
    }

    public void ShowAdEvent()
    {
        // Log an event with no parameters.
        Firebase
            .Analytics
            .FirebaseAnalytics
            .LogEvent("Show Ad");
    }
}