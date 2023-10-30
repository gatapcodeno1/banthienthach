using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryAbstract : DatMonoBehaviour
{
    [Header("InventoryAbstract")]
  
    
    [SerializeField] protected UIInventoryCtrl inventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => inventoryCtrl;


   

    protected override void LoadComponents()
    {
        base.LoadComponents();
        
        this.LoadInventoryCtrl();
    }


  

    /*protected virtual void SpawnTest(int i)
    {
        
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        uiItem.name = "Item " + i;
        uiItem.gameObject.SetActive(true);
    }*/




    

    protected virtual void LoadInventoryCtrl()
    {
        if (this.inventoryCtrl != null) return;

        this.inventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();

        Debug.Log(transform.name + "LoadInventoryCtrl", gameObject);


    }

}
