using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootAbleObjectCtrl : DatMonoBehaviour
{
    public Transform model;
    public Transform Model => model;

    public ShootAbleObjectSO shootAbleObject;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = this.transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);

    }

    protected virtual void LoadSO()
    {
        if (this.shootAbleObject != null) return;
        string resPath = "ShootAbleObject/"+this.GetObjectTypeString()+"/" + transform.name;
        this.shootAbleObject = Resources.Load<ShootAbleObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadJunkSO()", gameObject);

    }

    protected abstract string GetObjectTypeString();

}
