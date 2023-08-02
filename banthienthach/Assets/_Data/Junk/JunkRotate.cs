using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JunkRotate : JunkAbtract
{

    
    public float speed = 1;
    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    
    protected virtual void Rotating()
    {
        this.junkCtrl.Model.Rotate(new Vector3(0, 0, 1) * speed * 0.2f);
    }


}
