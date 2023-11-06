using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BtnExitGame : BtnBase
{
    protected override void OnClick()
    {

        Debug.Log("click");
        Application.Quit();
        
    }
}
