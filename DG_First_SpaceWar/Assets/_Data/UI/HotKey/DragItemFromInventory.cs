using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItemFromInventory : DatMonoBehaviour
{
   
    public virtual void Debugg()
    {
        ItemCode itemCode = ItemCodeParse.FromString(transform.Find("ItemName").GetComponent<Text>().text);
        UIInventoryCtrl.Instance.RemoveItem(itemCode, Int32.Parse(transform.Find("ItemNumber").GetComponent<Text>().text));
        ItemProfileSO SO = transform.GetComponent<UIItemInventory>().ItemProfileSO;

        if ((float)ShipCtrl.Instance.ObjShooting.timeDelay > 0.06f)
        {
            ShipCtrl.Instance.ObjShooting.timeDelay -= SO.SpeedAttackIncrease;
        }
        ShipCtrl.Instance.ObjMovement.GetComponent<ShipFollowMouse>().IncreaseSpeed(SO.SpeedIncrease);
        ShipCtrl.Instance.ShootAbleObjectDameReceive.Add((int)SO.HpIncrease);
    }

    
    

}
