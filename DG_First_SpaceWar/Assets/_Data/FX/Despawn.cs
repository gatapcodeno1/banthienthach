using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : DatMonoBehaviour
{

   protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }
   

    protected abstract bool CanDespawn();
   
   
  
   

    public virtual void DespawnObject()
    {
        FXSpawner.Instance.Despawner(transform.parent);
    }


}
