using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ShipMovement
{


    public Transform target;
    // Update is called once per frame
    protected override void FixedUpdate()
    {

        this.GetTargetPostition();
        base.FixedUpdate();

    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void GetTargetPostition()
    {
        this.targetPostition = this.target.position;
        this.targetPostition.z = 0;
    }

    protected override void Moving()
    {
        if(Vector3.Distance(target.position,transform.parent.position) < 1f)
        {
            return;
        }
        base.Moving();

    }
}
