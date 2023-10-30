using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class ItemPickupAble : ItemAbstract
{
    public SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    public static ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;

        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger= true;
        this.sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + "LoadSphereCollider", gameObject);

    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupAble.String2ItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        ItemDropSpawner.Instance.Despawner(transform.parent);
    }

    public virtual void OnMouseDown()
    {
        PlayerCtr.Instance.playerPickup.ItemPickup(this);
    }

}
