using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShield : BaseAbility
{
    [SerializeField] protected SphereCollider sphereCollider;

    [SerializeField] protected float timeActive = 3f;
    [SerializeField] protected float timeCurrent = 0f;
    [SerializeField] protected bool isActive = false;
    [SerializeField] protected GameObject gameobject;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadSpriteRenderer();
    }
    protected virtual void LoadSphereCollider()
    {
        this.sphereCollider = transform.GetComponent<SphereCollider>();
    }

    protected virtual void LoadSpriteRenderer()
    {
        this.gameobject = transform.GetChild(0).gameObject;
    }


    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ShieldActive();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckCanActiveShield();
    }

    protected virtual bool CheckCanActiveShield()
    {
        if(isReady == true && InputManager.Instance.OnTouchK != 0)
        {
            isActive = true;
            this.timeCurrent = 0f;
            return true;

        }
        return false;
    }


    protected virtual void ShieldActive()
    {
        if (isActive == false) return;
        if (timeCurrent > timeActive)
        {
            ShipCtrl.Instance.ShootAbleObjectDameReceive.sphereCollider.enabled = true;
            this.gameobject.gameObject.SetActive(false); 
            isActive = false;
            return;
        }
        else
        {
            timeCurrent += Time.fixedDeltaTime;
            ShipCtrl.Instance.ShootAbleObjectDameReceive.sphereCollider.enabled = false;
            this.gameobject.gameObject.SetActive(true);
            isActive = true;
        }
    }





}
