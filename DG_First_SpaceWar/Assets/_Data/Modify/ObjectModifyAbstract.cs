using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModifyAbstract : DatMonoBehaviour
{

    [SerializeField] protected ShootAbleObjectCtrl shootAbleObjectCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (shootAbleObjectCtrl != null) return;
        this.shootAbleObjectCtrl = transform.GetComponent<ShootAbleObjectCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl()", gameObject);
    }



}
