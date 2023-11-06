using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{

    public int maxLevel = 9;

    protected override void Start()
    {
        base.Start();
        Invoke("Test", 2);
        Invoke("Test", 3);
    }

    protected virtual void Test()
    {
        //this.UpgradeItem(0);
    }


    protected virtual bool UpgradeItem(int itemIndex) {
        if (itemIndex >= this.inventory.items.Count) return false;
        ItemInventory itemInventory = this.inventory.items[itemIndex];
        if (itemInventory.itemCount < 1) return false;
        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if (!this.ItemUpgradeAble(upgradeLevels)) return false;
        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;
        this.DeductIngredients(upgradeLevels,itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;
        return true;
    }

    protected virtual bool ItemUpgradeAble(List<ItemRecipe> upgradeLevels)
    {
           return upgradeLevels.Count > 0;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if (currentLevel > upgradeLevels.Count)
        {
            Debug.Log("Cant upgrade anymore" + currentLevel);
            return false;

        }

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach(ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;
            if (!this.inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;

    }


    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;
        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach(ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;
            this.inventory.DeductItem(itemCode, itemCount);
        }
    }

}
