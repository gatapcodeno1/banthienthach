using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShootByDistance : ShipShooting
{
    public Transform target;
    public float distance = Mathf.Infinity;
    public float minDistance = 3f;


    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }


    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(this.transform.position, this.target.position);
        this.isShooting = distance <= minDistance;
        return this.isShooting;
    }



}
