using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityThunder : BaseAbility
{

    [SerializeField] protected float curTime = 0f;
    [SerializeField] protected float activeTime = 3f;
    [SerializeField] protected float timeGap = 0.5f;
    [SerializeField] protected float time = 0f;
    [SerializeField] protected bool isActive = false;
    [SerializeField] protected bool dealDame = false;
    [SerializeField] protected int damePerTime = 3;
    [SerializeField] protected GameObject gameobject;


    protected override void Update()
    {
        base.Update();
        this.CheckCanActive();
    }

    protected virtual bool CheckCanActive()
    {
        if(isReady == true && InputManager.Instance.OnTouchT != 0)
        {
            isActive = true;
            return true;
        }
        return false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpriteRenderer();

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

    protected virtual void ShieldActive()
    {
        if (this.isActive == false) return;
        this.curTime += Time.fixedDeltaTime;
        this.time += Time.fixedDeltaTime;
        if(this.curTime > activeTime)
        {
            gameobject.gameObject.SetActive(false);
            curTime = 0f;
            isActive = false;
        }
        else
        {
            this.dealDame = false;
            gameobject.gameObject.SetActive(true);
        }
        

        if (this.time > this.timeGap)
        {
            dealDame = true;
            this.time = 0f;
        }
        else
        {
            dealDame = false;
        }

    }

   
    
    protected virtual void OnTriggerStay(Collider other)
    {
        
        if (this.dealDame == false) return;
        
        if (PlayerCtr.Instance.currentShip.transform == other.transform.parent) return;

        if (other.transform.parent.GetComponentInChildren<DameReceive>() == null) return;
        
        other.transform.parent.GetComponentInChildren<DameReceive>().Deduct(damePerTime);

        
    }






}
