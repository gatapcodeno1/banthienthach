using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : DatMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMeshPro();
    }

    protected virtual void LoadTextMeshPro()
    {
        this.textMeshProUGUI = transform.GetComponent<TextMeshProUGUI>();
    }

    

}
