using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class JunkDameReceive : DameReceive
{
    public JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtr();
    }

    protected virtual void LoadJunkCtr()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtr", gameObject);
    }

    

    protected override void Ondead()
    {
        GameObject.Destroy(transform.parent.gameObject);
        this.OndeadFX();
        this.OndeadDrop();

    }

    protected virtual void OndeadDrop()
    {
        Vector3 dropPos = transform.position;
        quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.junkSO.dropList, dropPos, dropRot);
    }

    protected virtual void OndeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }

    public override void Reborn()
    {
        this.hpMax = this.junkCtrl.junkSO.hpMax;
        base.Reborn();
    }

}
