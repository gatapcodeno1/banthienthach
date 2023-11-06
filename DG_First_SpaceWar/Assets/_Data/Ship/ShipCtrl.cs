using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    [Header("ShipCtrl")]
    public Inventory inventory;

    private static ShipCtrl instance;

    public static ShipCtrl Instance => instance;

    

    protected override void Awake()
    {
        base.Awake();
        ShipCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        


    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }
    protected virtual void LoadInventory()
    {
        this.inventory = GetComponentInChildren<Inventory>();
    }

   
}
