using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : DatMonoBehaviour
{
    public int damage = 1;

    public virtual void Send(Transform obj)
    {
        DameReceive dameReceive = obj.GetComponentInChildren<DameReceive>();
        if (dameReceive == null) return;
        this.Send(dameReceive);
        this.CreateFXImpact();

    }
    Transform a;
    protected virtual void CreateFXImpact()
    {
        string fxName = this.GetImpactFX();
        a = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        a.gameObject.SetActive(true);
       
    }

   
    protected virtual string GetImpactFX()
    {
        return FXSpawner.flash1;
    }


    public virtual void Send(DameReceive damereceive)
    {
        damereceive.Deduct(this.damage);
        
    }

    


}
