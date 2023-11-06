using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjLookAtMouse : ObjLookAtTarget
{

    protected override void Awake()
    {
        this.rotSpeed = 6f;
       
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {

        this.GetMousePostition();
        base.FixedUpdate();



    }

    protected virtual void GetMousePostition()
    {

        this.targetPostition = InputManager.Instance.MousePosition;

    }




}
