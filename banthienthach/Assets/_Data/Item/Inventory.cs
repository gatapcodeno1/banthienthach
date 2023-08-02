using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : DatMonoBehaviour
{
    public int maxSlot = 70;
    public List<ItemInventory> items;


    protected override void Start()
    {
        base.Start();
        
        this.AddItem(ItemCode.WoodSword, 3);
        this.AddItem(ItemCode.IronOre, 21);
        this.AddItem(ItemCode.GoldOre, 22);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        ItemInventory itemExist;

        for (int i = 0; i < maxSlot; i++)
        {
            itemExist = this.GetItemNotFullStack(itemCode);

            if(itemExist == null)
            {
                itemExist = this.CreateEmptyItem(itemProfile);

                if (this.IsInventoryFull()) return false;

                this.items.Add(itemExist);
            }

            int mn = Mathf.Min(addCount, GetMaxStack(itemExist) - itemExist.itemCount);
            itemExist.itemCount += mn;
            addCount -= mn;


            if (addCount < 1) break;
        }
        return true;
    }


    public virtual void DeductItem(ItemCode itemCode , int deductCount)
    {

        ItemInventory itemInventory;

        for(int i = this.items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];

            if (itemInventory.itemProfile.itemCode != itemCode) continue;

            int mn = Mathf.Min(deductCount, itemInventory.itemCount);
            itemInventory.itemCount -= mn;
            deductCount -= mn;
        }
        this.ClearEmptySlot();

    }

    public virtual bool ItemCheck(ItemCode itemCode , int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount > numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory item in this.items)
        {
            if (itemCode != item.itemProfile.itemCode) continue;
            totalCount += item.itemCount;
        }
        return totalCount;
    }

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    protected virtual bool IsInventoryFull()
    {
        return this.items.Count >= maxSlot;
    }


    public virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item",typeof(ItemProfileSO));

        foreach(ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode ) continue;
            return profile;
        }
        return null;
    }



    public virtual ItemInventory GetItemNotFullStack(ItemCode itemCode) { 
    
        

        foreach (ItemInventory item in items)
        {
            if (item.itemProfile.itemCode != itemCode) continue;
            
            if (this.IsFullStack(item)) continue;

            return item;
        }
        return null;

        
    }

    protected virtual bool IsFullStack(ItemInventory item)
    {
        if (item == null) return true;

        int maxStack = this.GetMaxStack(item);
        return item.itemCount >= maxStack;

    }


    public virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };
        return itemInventory;
    }
    
    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for(int i = items.Count-1; i >= 0; i--)
        {
            itemInventory = items[i];
            if (itemInventory.itemCount == 0) this.items.RemoveAt(i); 
        }
    }

}

