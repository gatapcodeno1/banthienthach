using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjMovement : DatMonoBehaviour
{

    [SerializeField]protected Vector3 targetPostition;
    [SerializeField] protected float speed = 0.1f;
   

    // Update is called once per frame

    protected override void Awake()
    {
        base.Awake();
        
    }

    protected virtual void FixedUpdate()
    {

        this.Moving();

    }



    public virtual void SetSpeed(float Speed)
    {
        this.speed = Speed;
    }

    protected virtual void Moving()
    {
        if (Vector2.Distance(transform.parent.position, targetPostition) < 1f) return;
        Vector2 newPos = Vector2.Lerp(transform.parent.position, targetPostition, speed);
        
        transform.parent.position = newPos;
    }

    

}
