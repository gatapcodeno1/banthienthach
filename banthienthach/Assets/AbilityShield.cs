using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShield : BaseAbility
{
    [SerializeField] protected CircleCollider2D circleCollider2D;
    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }
    protected virtual void LoadCircleCollider2D()
    {
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
       
        
    }

}
