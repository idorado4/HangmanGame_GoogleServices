using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDispatcher : IEventDispatcherService
{
 
    private readonly Dictionary<Type, dynamic> _events;
    
    public EventDispatcher()
    {
        _events = new Dictionary<Type, dynamic>();
    }

    public void Subscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (!_events.ContainsKey(type))
        {
            _events.Add(type, null);
        }

        _events[type] += callback;
    }

    public void Unsubscribe<T>(Action<T> callback)
    {
        var type = typeof(T);
        if (_events.ContainsKey(type))
        {
            _events[type] -= callback;
        }
    }

    public void Dispatch<T>(T signal)
    {
        Debug.Log("dispatch called");
        var type = typeof(T);
        if (!_events.ContainsKey(type))
            return;
        _events[type](signal);
    }
}