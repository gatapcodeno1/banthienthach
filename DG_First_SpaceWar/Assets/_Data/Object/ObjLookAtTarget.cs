using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjLookAtTarget : DatMonoBehaviour
{

    [SerializeField]protected Vector3 targetPostition;
    [SerializeField] protected float rotSpeed = 3f;

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {

       
        this.LookAtTarget();
       



    }

    public virtual void SetRotSpeed(float RotSpeed)
    {
        this.rotSpeed = RotSpeed;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPostition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y,diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
        Quaternion targetEuler =   Quaternion.Euler(0f,0f,rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;


    }

   
    

}
