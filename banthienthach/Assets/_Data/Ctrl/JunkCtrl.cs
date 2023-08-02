using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : DatMonoBehaviour
{
    public Transform model;
    public Transform Model { get => model; }

    public JunkSO junkSO;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = this.transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }

    protected virtual void LoadJunkSO()
    {
        if(this.junkSO != null) return;
        string resPath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(resPath);
        Debug.Log(transform.name + ": LoadJunkSO()", gameObject);

    }

}
