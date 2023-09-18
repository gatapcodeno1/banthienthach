using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShipHP : BaseText
{

    protected virtual void FixedUpdate()
    {
        
        this.UpdateShipHP();
    }
    protected virtual void UpdateShipHP()
    {
        int ShipHP = ShipCtrl.Instance.ShootAbleObjectDameReceive.hp;
        this.textMeshProUGUI.SetText(" " + ShipHP);
    }

}
