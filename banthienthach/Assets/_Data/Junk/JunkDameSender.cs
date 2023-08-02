using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameSender : DamageSender
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.parent != BulletSpawner.Instance.shooter) return;
       

        GameObject.Destroy(transform.parent.gameObject);
        Transform a = FXSpawner.Instance.Spawn(FXSpawner.smoke1,this.transform.position ,this.transform.rotation);    
        a.gameObject.SetActive(true);
        Send(other.transform);
        
    }
    

    
}
