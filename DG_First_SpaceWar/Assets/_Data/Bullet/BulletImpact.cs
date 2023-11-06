using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbtract
{
    public SphereCollider sphereCollider;
    public Rigidbody _rigidbody;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
        
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    


    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        BulletInfo par = transform.parent.GetComponentInChildren<BulletInfo>();
        if(other.transform.parent == par.GetShooter())  return;
        //Debug.Log(other.transform.parent + " andddddddddddddd " + BulletInfo.Instance.GetShooter());
        this.bulletCtrl.damageSender.Send(other.transform);
        
        
    }


    


}
