using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : DatMonoBehaviour
{
    private static UIInventoryCtrl instance;

    public static UIInventoryCtrl Instance => instance;

    [SerializeField] protected UIInventorySpawner inventorySpawner;
    public UIInventorySpawner UIInventorySpawner => inventorySpawner;


    [SerializeField] protected Transform content;
    public Transform Content => content;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInventorySpawner();
    }


   


    protected override void Awake()
    {
        base.Awake();
        if (UIInventoryCtrl.Instance != null) Debug.Log("Only 1 UIInventoryCtrl allow to exitst");
        UIInventoryCtrl.instance= this; 
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;

        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        
        Debug.Log(transform.name + "LoadContent", gameObject);


    }

    protected virtual void LoadUIInventorySpawner()
    {
        if (this.inventorySpawner != null) return;

        this.inventorySpawner = transform.GetComponentInChildren<UIInventorySpawner>();

        Debug.Log(transform.name + "LoadUIInventorySpawner", gameObject);


    }

}
