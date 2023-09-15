using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ObjMovement
{


    public Transform target;

    public float distance = Mathf.Infinity;
    public float minDistance = 2f;

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
       
    }

    protected override void Moving()
    {
        distance = Vector2.Distance(transform.parent.position, targetPostition);
        if (Vector2.Distance(transform.parent.position, targetPostition) < this.minDistance) return;
        Vector2 newPos = Vector2.Lerp(transform.parent.position, targetPostition, speed);

        transform.parent.position = newPos;
    }


}
