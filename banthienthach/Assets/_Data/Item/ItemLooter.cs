using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : InventoryAbstract
{

    
    public SphereCollider sphereCollider;
    public Rigidbody _rigidbody;


    protected override void LoadComponents()
    {
        base.LoadComponents();
       
        this.LoadRigidbody();
        this.LoadSphereCollider();
        
    }

    

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ": LoadSphereCollider()", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        this._rigidbody.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody()", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
       
        ItemPickupAble itemPickupAble = other.GetComponent<ItemPickupAble>();
        if (itemPickupAble == null) return;

        ItemCode itemCode = itemPickupAble.GetItemCode();
        if(inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Picked();
        }

    }



}
