
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : DatMonoBehaviour
{
    [SerializeField] protected PlayerCtr playerCtr;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtr();
    }

    protected virtual void LoadPlayerCtr()
    {
        if (this.playerCtr != null) return;
        this.playerCtr = transform.GetComponentInParent<PlayerCtr>();
        Debug.Log(transform.name + ": LoadPlayerCtr()", gameObject);
    }

}