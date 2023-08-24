using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();

        if (ItemDropSpawner.instance != null) Debug.Log("Only 1 Dropmanager allow");

        ItemDropSpawner.instance = this;

    }

    public virtual void Drop(List<DropRate> dropList , Vector3 pos , Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        
        itemDrop.gameObject.SetActive(true);
        
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos , Quaternion rot) {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);

        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();

        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;

    }

}