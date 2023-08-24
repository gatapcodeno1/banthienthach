using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupAble.GetItemCode();
        ItemInventory itemInventory = itemPickupAble.itemCtrl.itemInventory;
        if (this.playerCtr.CurrentShip.inventory.AddItem(itemInventory))
        {
            itemPickupAble.Picked();
        }

    }
}
