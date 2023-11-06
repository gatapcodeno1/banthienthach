using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipSpeedShoot : BaseText
{
    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {

        this.UpdateShipDame();
    }
    protected virtual void UpdateShipDame()
    {
        float ShipSpeed = 1f/(ShipCtrl.Instance.ObjShooting.timeDelay);
        this.textMeshProUGUI.SetText("Speed shoot: " + (int)ShipSpeed);
    }
}
