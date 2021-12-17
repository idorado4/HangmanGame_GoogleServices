using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewModelBase : IDisposable
{
    protected List<IDisposable> _disposables = new List<IDisposable>();

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    } 
}