using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : DatMonoBehaviour
{
    public Transform target;
    public float speed = 0.5f;


    protected virtual void FixedUpdate()
    {
        
        this.Following();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();  
        
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("Ship").transform;
        Debug.Log(transform.name + "LoadTarget ", gameObject);
    }


    protected virtual void Following()
    {
        if (this.target == null) return;
       
        transform.position = Vector3.Lerp(transform.position,this.target.position,Time.fixedDeltaTime * this.speed);
        
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

}
