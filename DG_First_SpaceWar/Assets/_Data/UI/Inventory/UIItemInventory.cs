using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : DatMonoBehaviour
{
    [Header("UIItemInventory")]

    private static UIItemInventory instance;
    public static UIItemInventory Instance { get => instance; }

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected ItemProfileSO itemProfileSO;
    public ItemProfileSO ItemProfileSO => itemProfileSO;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumber => itemNumber;

    

    [SerializeField] protected Image itemSprite;
    public Image ItemSprite => itemSprite;

    protected override void Awake()
    {
        base.Awake();
        UIItemInventory.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
       
        this.LoadItemNumber();
        this.LoadItemSprite();
    }

    protected virtual void LoadItemName()
    {
        
        if (this.itemName != null) return;

        this.itemName = transform.Find("ItemName").GetComponent<Text>();
        Debug.Log(transform.name + "LoadItemName", gameObject);
    }


    

    protected virtual void LoadItemNumber()
    {

        if (this.itemNumber != null) return;

        this.itemNumber = transform.Find("ItemNumber").GetComponent<Text>();

            

        Debug.Log(transform.name + "LoadItemNumber", gameObject);


    }

    protected virtual void LoadItemSprite()
    {

        if (this.itemSprite != null) return;

        this.itemSprite = transform.Find("ItemSprite").GetComponent<Image>();



        Debug.Log(transform.name + "LoadItemSprite", gameObject);


    }
        

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = this.itemInventory.itemProfile.itemName;
        this.itemNumber.text = this.itemInventory.itemCount.ToString();
        this.itemSprite.sprite = this.itemInventory.itemProfile.sprite;
        this.itemProfileSO = this.itemInventory.itemProfile;
    }


}