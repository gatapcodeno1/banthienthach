using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipFollowTarget : ObjMovement
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

    }


    protected override void Moving()
    {
        base.Moving();
        this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y , 1);

    }
}
