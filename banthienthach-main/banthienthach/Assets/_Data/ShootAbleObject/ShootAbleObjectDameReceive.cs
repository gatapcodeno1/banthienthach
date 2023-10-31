using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShootAbleObjectDameReceive : DameReceive
{
    public ShootAbleObjectCtrl ShootAbleObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootAbleObjectCtrl();
    }

    protected virtual void LoadShootAbleObjectCtrl()
    {
        if (this.ShootAbleObjectCtrl != null) return;
        this.ShootAbleObjectCtrl = transform.parent.GetComponent<ShootAbleObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootAbleObjectCtrl", gameObject);
    }

    

    protected override void Ondead()
    {
        EnemySpawner nowSpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        nowSpawner.Despawner(transform.parent);
        
        Debug.Log("chet rui ne");
        this.OndeadFX();
        this.OndeadDrop();
        
    }

    protected virtual void OndeadDrop()
    {
        Vector3 dropPos = transform.position;
        quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.ShootAbleObjectCtrl.ShootAbleObjectSO.dropList, dropPos, dropRot);
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
        this.hpMax = this.ShootAbleObjectCtrl.ShootAbleObjectSO.hpMax;
        base.Reborn();
    }

}
