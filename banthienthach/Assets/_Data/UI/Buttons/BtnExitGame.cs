using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BtnExitGame : BtnBase
{
    protected override void OnClick()
    {


        EditorApplication.ExitPlaymode();
        Application.Quit();
        
    }
}
