using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipMovement : DatMonoBehaviour
{

    protected Vector3 targetPostition;
    public float speed = 0.1f;

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {

       
        this.LookAtTarget();
        this.Moving();



    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPostition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f,0f,rot_z);
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPostition, speed);
        newPos.z = 0f;
        transform.parent.position = newPos;
    }

}
