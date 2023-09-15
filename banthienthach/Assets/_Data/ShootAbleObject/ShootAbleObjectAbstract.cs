using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootAbleObjectAbstract : DatMonoBehaviour
{
    [Header("ShootAbleObjectAbstract")]
    

    [SerializeField] protected ShootAbleObjectCtrl shootAbleObjectCtrl;
    public ShootAbleObjectCtrl ShootAbleObjectCtrl => shootAbleObjectCtrl;  



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootAbleObject();
    }

   

    protected virtual void LoadShootAbleObject()
    {
        if (this.shootAbleObjectCtrl != null) return;
        this.shootAbleObjectCtrl = transform.parent.GetComponent<ShootAbleObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootAbleObject", gameObject);
    }


   

}
