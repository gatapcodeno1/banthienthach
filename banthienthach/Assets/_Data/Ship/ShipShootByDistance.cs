using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShootByDistance : ObjShooting
{
    public Transform target;
    public float distance = Mathf.Infinity;
    public float minDistance = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }

    public virtual void SetTarget(Transform target)
    {
        /*this.target = target;*/
    }


    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(this.transform.position, this.target.position);
        this.isShooting = distance <= minDistance;
        return this.isShooting;
    }



}
