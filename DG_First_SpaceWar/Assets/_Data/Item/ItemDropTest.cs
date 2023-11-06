using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDropTest : DatMonoBehaviour
{

    public JunkCtrl junkCtrl;
    public List<ItemDropCount> dropCountItems = new List<ItemDropCount>();
    public int dropCount = 0;

    protected override void Start()
    {
        base.Start();

        InvokeRepeating(nameof(this.Dropping), 2, 0.1f);
    }

    protected virtual void Dropping()
    {
        dropCount++;
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        List <ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.shootAbleObject.dropList, dropPos, dropRot);
        ItemDropCount itemDropCount;
        foreach(ItemDropRate itemDropRate in dropItems)
        {
            itemDropCount = this.dropCountItems.Find(i => i.itemName == itemDropRate.itemSO.itemName);
            if(itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = itemDropRate.itemSO.itemName;
                this.dropCountItems.Add(itemDropCount);
            }
            itemDropCount.count++;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.count / this.dropCount,2);

        }




    }

                                                                                                        

}

[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}