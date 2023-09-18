using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("AbilityWarp")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected bool isWarping = false;
    protected Vector4 keyDirection;
    [SerializeField] protected Vector4 warpDirection;
    [SerializeField] protected float warpSpeed = 1f;
    [SerializeField] protected float warpDistance = 1f;

    protected override void Update()
    {
        base.Update();
        this.CheckWarpDirection();

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Warping();
    }


    protected virtual void CheckWarpDirection()
    {
        if (isReady == false) return;
        //if (this.isWarping) return;
        if (this.keyDirection.x == 1) this.WarpLeft();
        if (this.keyDirection.y == 1) this.WarpRight();
        if (this.keyDirection.z == 1) this.WarpUp();
        if (this.keyDirection.w == 1) this.WarpDown();

        /*if (this.keyDirection.x == 1) Debug.Log("Left");
        if (this.keyDirection.y == 1) Debug.Log("Right");
        if (this.keyDirection.z == 1) Debug.Log("Up");
        if (this.keyDirection.w == 1) Debug.Log("Down");*/
    }

    protected virtual void Warping()
    {
        if (this.isWarping == true) return;
        if (this.IsDirectionNotSet()) return;
        Debug.Log(this.warpDirection);
        this.isWarping = true;
        Invoke(nameof(this.WarpFinish), this.warpSpeed);

    }

    protected virtual bool IsDirectionNotSet()
    {
        return  this.warpDirection == Vector4.zero;
    }


    protected virtual void WarpFinish()
    {
        Debug.Log("WarpFinish");
        this.MoveObj();
        this.warpDirection = Vector4.zero;
        this.isWarping = false;
        this.Active();
    }

    protected virtual void MoveObj()
    {
        Transform obj = this.abilities.AbilityObjectCtrl.transform;
        Vector3 newPos = obj.position;
        if (this.warpDirection.x == 1) newPos.x -= this.warpDistance;
        if (this.warpDirection.y == 1) newPos.x += this.warpDistance;
        if (this.warpDirection.z == 1) newPos.y += this.warpDistance;
        if (this.warpDirection.w == 1) newPos.y -= this.warpDistance;

        Quaternion fxRot = this.GetFxQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.flash1,obj.position, fxRot);
        fx.localScale = new Vector3(.4f, .4f , .4f);
        fx.gameObject.SetActive(true);
        obj.position = newPos;
        

    }


    protected virtual Quaternion GetFxQuaternion()
    {
        Vector3 vector = new Vector3();
        if (this.warpDirection.x == 1) vector.z = -90;
        if (this.warpDirection.y == 1) vector.z = 90;
        if (this.warpDirection.z == 1) vector.z = 180;
        if (this.warpDirection.w == 1) vector.z = 0;

        if (this.warpDirection.x == 1 && this.warpDirection.w == 1) vector.z = -45;
        if (this.warpDirection.y == 1 && this.warpDirection.w == 1) vector.z = 45;
        if (this.warpDirection.x == 1 && this.warpDirection.z == 1) vector.z = -135;
        if (this.warpDirection.y == 1 && this.warpDirection.z == 1 ) vector.z = 135;

        return Quaternion.Euler(vector);

    }



    protected virtual void WarpLeft()
    {
        Debug.Log("Warp Left");
        this.warpDirection.x = 1;
    }

    protected virtual void WarpRight()
    {
        
        Debug.Log("Warp Right");
        this.warpDirection.y = 1;
    }

    protected virtual void WarpUp()
    {

        Debug.Log("Warp Right");
        this.warpDirection.z = 1;
    }

    protected virtual void WarpDown()
    {

        Debug.Log("Warp Right");
        this.warpDirection.w = 1;
    }

}
