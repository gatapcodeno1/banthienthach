
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class JunkFly : ObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        
        this.movespeed = 2f;
        this.direction = this.GetDirection();
        



    }

    protected virtual Vector3 GetDirection()
    {

        float x = Random.Range(-1f, 1f);
        return new Vector3(x, -1, 0);
    }


    public override void FixedUpdate()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);

    }

    
    

   

}
