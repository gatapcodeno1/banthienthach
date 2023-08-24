using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DatMonoBehaviour
{
    public DamageSender damageSender;


    protected override void Reset()
    {
        base.Reset();

        if (this.damageSender != null) return;
        damageSender = transform.GetComponentInChildren<DamageSender>();
    

    }

}
