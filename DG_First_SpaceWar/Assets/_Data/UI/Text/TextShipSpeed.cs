using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipSpeed : BaseText
{
    protected virtual void FixedUpdate()
    {

        this.UpdateShipHP();
    }
    protected virtual void UpdateShipHP()
    {
        float ShipSpeedRun = ShipCtrl.Instance.ObjMovement.GetComponent<ShipFollowMouse>().GetSpeed() * 1000;
        this.textMeshProUGUI.SetText("Speed: " + (int)ShipSpeedRun);
    }
}
