using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : DatMonoBehaviour
{
    public Inventory inventory;

    private static ShipCtrl instance;

    public static ShipCtrl Instance => instance;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        ShipCtrl.instance = this;  
        this.inventory = GetComponentInChildren<Inventory>();
    }
}
