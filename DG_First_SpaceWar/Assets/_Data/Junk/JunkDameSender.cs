using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameSender : DamageSender
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.parent != PlayerCtr.Instance.currentShip.transform) return;
        JunkSpawner.Instance.Despawner(transform.parent);
        Transform a = FXSpawner.Instance.Spawn(FXSpawner.smoke1,this.transform.position ,this.transform.rotation);    
        a.gameObject.SetActive(true);
        Send(other.transform);
        

        
        
    }



}
