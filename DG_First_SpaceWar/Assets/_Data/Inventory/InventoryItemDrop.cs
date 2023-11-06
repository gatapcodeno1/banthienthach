using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemDrop : InventoryAbstract
{
    protected override void Start()
    {
        base.Start();
        Invoke("Test", 6);


    }


    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int index)
    {
        ItemInventory itemInventory = this.inventory.items[index];
        
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.DropFromInventory(itemInventory, dropPos, transform.rotation);
        this.inventory.items.Remove(itemInventory);
        
    }

}
