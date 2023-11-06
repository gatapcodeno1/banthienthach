using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipModify : ObjectModifyAbstract
{
    [Header("EnemyShipModify")]
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float rotSpeed = 2f;

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
