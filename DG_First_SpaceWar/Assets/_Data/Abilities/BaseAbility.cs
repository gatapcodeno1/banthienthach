using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : DatMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;

    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;


    protected virtual void FixedUpdate()
    {
        this.Timing();
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAbilities();
    }

    protected virtual void Update()
    {
            
    }


    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;

        this.abilities = transform.parent.GetComponent<Abilities>();

        Debug.Log(transform.name + ": LoadAbilities()", gameObject);

    }



    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }

    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }

}
