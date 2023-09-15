using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjMoveFoward : ObjMovement
{

    [SerializeField] protected Transform target;


   

    // Update is called once per frame
    protected override void FixedUpdate()
    {

        this.GetMousePostition();
        base.FixedUpdate();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        this.target = transform.Find("MoveFoward");
    }

    protected virtual void GetMousePostition()
    {

        this.targetPostition = target.position;

    }


}
