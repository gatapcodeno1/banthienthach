using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFly : DatMonoBehaviour
{
    public float movespeed = 9f;
    public Vector3 direction = Vector3.up;

    public virtual void FixedUpdate()
    {
      
        //transform.parent.Translate(this.direction);
    }

    

}
