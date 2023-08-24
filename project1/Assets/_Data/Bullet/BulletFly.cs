using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ObjectFly
{

    protected override void ResetValue()
    {
        base.ResetValue();

        this.movespeed = 20f;

    }

    public override void FixedUpdate()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }

}
