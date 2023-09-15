using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjectModifyAbstract
{
    [Header("MotherShipModify")]
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed = 0.01f;

    protected override void Start()
    {
        base.Start();
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        this.shootAbleObjectCtrl.ObjMovement.SetSpeed(this.speed);
        this.shootAbleObjectCtrl.ObjLookAtTarget.SetRotSpeed(this.rotSpeed);
    }

}
