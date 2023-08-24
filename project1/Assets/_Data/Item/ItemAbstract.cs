using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbstract : DatMonoBehaviour
{
    public ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl { get => itemCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);

    }
}