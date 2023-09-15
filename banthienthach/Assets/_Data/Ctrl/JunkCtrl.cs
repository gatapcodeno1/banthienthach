using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : DatMonoBehaviour
{
    public Transform model;
    public Transform Model { get => model; }

    public ShootAbleObjectSO shootAbleObject;


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
        if(this.shootAbleObject != null) return;
        string resPath = "ShootAbleObject/Junk/" + transform.name;
        this.shootAbleObject = Resources.Load<ShootAbleObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadJunkSO()", gameObject);

    }

}
