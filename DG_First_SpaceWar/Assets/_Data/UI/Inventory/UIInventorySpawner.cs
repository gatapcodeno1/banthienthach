using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventorySpawner : Spawner
{
    // Start is called before the first frame update
    private static UIInventorySpawner instance;

    public static UIInventorySpawner Instance => instance;

    public static string normalItem = "UIInventoryItem";


    [Header("UIInventorySpawner")]

    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;


    

    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;

        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();  

        Debug.Log(transform.name + "LoadHolder", gameObject);
    }

    protected override void Awake()
    {
        base.Awake();
        if (UIInventorySpawner.instance != null) Debug.Log("Only 1 UIInventorySpawer allow to exist");
        UIInventorySpawner.instance = this;

    }

    protected override void LoadHolder()
    {
        this.LoadUIInventoryCtrl();
        if (this.holder != null) return;

        this.holder = this.inventoryCtrl.Content;


        Debug.Log(transform.name + "LoadHolder", gameObject);


    }

    public virtual void ClearItems()
    {
        foreach(Transform item in this.holder)
        {
            this.Despawner(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.inventoryCtrl.UIInventorySpawner.Spawn(UIInventorySpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>(); 
        itemInventory.ShowItem(item);
        uiItem.gameObject.SetActive(true);
    }


}
