using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DatMonoBehaviour
{
    public DamageSender damageSender;

    [SerializeField] protected BulletIncrease bulletIncrease;
    [SerializeField] protected BulletFly bulletFly;


    public  BulletFly BulletFly => bulletFly;

    public BulletIncrease BulletIncrease => bulletIncrease;


    protected override void Reset()
    {
        base.Reset();

        if (this.damageSender != null) return;
        damageSender = transform.GetComponentInChildren<DamageSender>();
    

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletIncrease();
        this.LoadBulletFly();
    }

    protected virtual void LoadBulletFly()
    {
        if (this.bulletFly != null) return;
        this.bulletFly = transform.GetComponentInChildren<BulletFly>();
        Debug.Log(transform.name + ": LoadBulletFly", gameObject);
    }
    protected virtual void LoadBulletIncrease()
    {
        if (this.BulletIncrease != null) return;
        this.bulletIncrease = transform.GetComponentInChildren<BulletIncrease>();
        Debug.Log(transform.name + ": LoadBulletIncrease", gameObject);
    }

}
