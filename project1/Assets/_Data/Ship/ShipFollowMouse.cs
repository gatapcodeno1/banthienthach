using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ShipMovement
{

    

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
