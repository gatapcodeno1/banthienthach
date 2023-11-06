using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbtract : DatMonoBehaviour
{
    public BulletCtrl bulletCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDamageRecieve();
    }

    protected virtual void LoadDamageRecieve()
    {
        if (this.bulletCtrl != null) return;

        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadDamageRecieve", gameObject);

    }


}
