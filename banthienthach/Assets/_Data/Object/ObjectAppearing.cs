using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class ObjectAppearing : DatMonoBehaviour
{
    [Header("ObjectAppearing")]
    [SerializeField] protected bool isAppearing = false;
    [SerializeField] protected bool appread = false;
    [SerializeField] protected List<IObjAppearObserver> observes = new List<IObjAppearObserver>();

    public bool IsAppearing => isAppearing;
    public bool Appread => appread;

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();

    }

    protected abstract void Appearing();
    
    public virtual void Appear()
    {
        this.appread = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }

    public virtual void ObservesAdd(IObjAppearObserver observer)
    {
        this.observes.Add(observer);

    }

    protected virtual void OnAppearStart()
    {
        foreach(IObjAppearObserver observer in this.observes)
        {
            observer.OnAppearStart(); 
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjAppearObserver observer in this.observes)
        {
            observer.OnAppearFinish();
        }
    }

}
