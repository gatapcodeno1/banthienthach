using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public abstract class DameReceive : DatMonoBehaviour
{
    
    public SphereCollider sphereCollider;
    public int hp = 1;
    public int hpMax = 2;
    public bool isDead = false;
    [SerializeField] Spawner spawner;
    protected Spawner Spawner => spawner;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadSpawner();
        
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform+"LoadSpawner",gameObject);
        
    }


    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    
    

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Deduct( int deduct)
    {
        this.hp -= deduct;
        if(this.hp <= 0)
        {
            this.hp = 0;
            
        }
        this.CheckIsDead();
    }

    public virtual void Add(int add)
    {
        this.hp += add;
        if (this.hp > this.hpMax)
        {
            this.hp = this.hpMax;
        }
    }

    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;

        this.isDead = true;
        this.Ondead();

    }

    protected abstract void Ondead();
}
