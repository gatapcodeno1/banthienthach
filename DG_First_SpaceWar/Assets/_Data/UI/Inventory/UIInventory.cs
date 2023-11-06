using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UIInventory")]
    private static UIInventory instance;

    public static UIInventory Instance => instance;
    protected bool isOpen = false;

    [SerializeField] protected UIInventorySort inventorySort = UIInventorySort.ByName;


    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.Instance != null) Debug.Log("Only 1 UIInventory allow to exitst");
        UIInventory.instance = this;
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen)
        {
            this.Open();
        }
        else
        {
            this.Close();
        }
    }

    protected override void Start()
    {
        base.Start();
        this.Close();
        InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }
    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }




    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.inventoryCtrl.gameObject.SetActive(true);
    }

    public virtual void Close()
    {
        this.inventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }
    protected virtual void ShowItems()
    {
        
        if (!this.isOpen) return;
        this.ClearItems();
        List<ItemInventory> items = PlayerCtr.Instance.currentShip.inventory.items;
        UIInventorySpawner spawner = this.inventoryCtrl.UIInventorySpawner;


        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
        this.SortItems();


    }

    protected virtual void SortItems()
    {
        switch(this.inventorySort)
        {
            case UIInventorySort.ByName:
                this.SortByName();
                break;
            case UIInventorySort.ByCount:
                break;
            default:
                break;
        }
    }

    protected virtual void SortByName()
    {
        int itemCount = this.UIInventoryCtrl.Content.childCount;
        for(int i = 0; i < itemCount; i++)
        {
            for(int j = i+1; j < itemCount; j++)
            {
                if  (string.Compare(this.inventoryCtrl.Content.GetChild(i).GetComponent<UIItemInventory>().ItemInventory.itemProfile.itemName,this.inventoryCtrl.Content.GetChild(j).GetComponent<UIItemInventory>().ItemInventory.itemProfile.itemName) == -1)
                {
                    this.Swap(this.inventoryCtrl.Content.GetChild(i), this.inventoryCtrl.Content.GetChild(j));
                }
            }

        }
    }

    protected virtual void Swap(Transform a, Transform b)
    {
        int curindx = a.GetSiblingIndex();
        int nextindx = b.GetSiblingIndex();

        a.SetSiblingIndex(nextindx);
        b.SetSiblingIndex(curindx);

    }



    protected virtual void ClearItems()
    {
        this.inventoryCtrl.UIInventorySpawner.ClearItems();
    }




}
