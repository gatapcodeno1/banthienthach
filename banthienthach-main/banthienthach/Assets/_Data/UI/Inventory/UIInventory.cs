using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : DatMonoBehaviour
{
    private static UIInventory instance;

    public static UIInventory Instance => instance;
    protected bool isOpen = false;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.Instance != null) Debug.Log("Only 1 UIInventory allow to exitst");
        UIInventory.instance= this; 
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen ) { 
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
        //this.Close();
    }
    protected virtual void FixedUpdate()
    {
        this.ShowItem();
    }




    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }
    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        float ItemCount = PlayerCtr.Instance.currentShip.inventory.items.Count;
        Debug.Log("" + ItemCount);
    }
}
