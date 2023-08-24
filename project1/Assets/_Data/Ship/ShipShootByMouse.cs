using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShootByMouse : ShipShooting
{


    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring != 0;
        return this.isShooting;
    }



}
