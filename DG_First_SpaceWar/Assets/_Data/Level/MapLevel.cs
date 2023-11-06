using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTarget();
    }

    protected virtual void MapSetTarget()
    {
        if (this.target != null) return;
        ShipCtrl currentShip = PlayerCtr.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
        Debug.Log(transform.name + ": MapSetTarget", gameObject);
    }
}
