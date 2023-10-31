﻿using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public Sprite sprite;
    public List<ItemRecipe> upgradeLevels;
    public float HpIncrease = 5f;
    public float SpeedIncrease = 0.01f;
    public float SpeedAttackIncrease = 1f;
   


    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item",typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

}


