using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : DatMonoBehaviour
{

    public ItemInventory itemInventory;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        
       
        
        ItemCode itemCode = ItemCodeParse.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.itemInventory.upgradeLevel = itemProfile.upgradeLevels.Count;
        this.itemInventory.maxStack = itemProfile.defaultMaxStack;
        this.itemInventory.itemCount = 1;
        
       
       


    }



    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

}
