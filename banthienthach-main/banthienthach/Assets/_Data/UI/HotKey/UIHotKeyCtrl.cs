using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : DatMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance { get => instance; }

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.Log("Only 1 UIHotKey allow to exist");
        UIHotKeyCtrl.instance = this;
    }


}
