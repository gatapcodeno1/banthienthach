using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectWithoutShooting : ShootAbleObjectAbstract,IObjAppearObserver
{
    [Header("ObjectWithoutShooting")]
    [SerializeField] protected ObjectAppearing objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAppearing();
    }

    protected virtual void LoadObjectAppearing()
    {
        if (this.objectAppearing != null) return;
        this.objectAppearing = GetComponent<ObjectAppearing>();
        Debug.Log(transform.name + ": LoadObjectAppearing", gameObject);
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objectAppearing.ObservesAdd(this);
    }

    public void OnAppearStart()
    {
       this.shootAbleObjectCtrl.ObjShooting.gameObject.SetActive(false);
       this.shootAbleObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
       this.shootAbleObjectCtrl.ShipFollowTarget.gameObject.SetActive(false);
       
    }

    public void OnAppearFinish()
    {
        this.shootAbleObjectCtrl.ObjShooting.gameObject.SetActive(true);
        this.shootAbleObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);
        this.shootAbleObjectCtrl.ShipFollowTarget.gameObject.SetActive(true);

    }
}
