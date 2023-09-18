using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCloseInventory : BtnBase
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
