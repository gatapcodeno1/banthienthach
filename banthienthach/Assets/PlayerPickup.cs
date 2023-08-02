using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupAble.GetItemCode();
        if (this.playerCtr.CurrentShip.inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Picked();
        }

    }
}
