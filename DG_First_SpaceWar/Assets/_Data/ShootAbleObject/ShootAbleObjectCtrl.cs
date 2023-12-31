using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ShootAbleObjectCtrl : DatMonoBehaviour
{
    [Header("ShootAbleObjectCtrl")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    
    [SerializeField] protected ShootAbleObjectSO shootAbleObject;
    public ShootAbleObjectSO ShootAbleObjectSO => shootAbleObject;

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;

    [SerializeField] protected ShipFollowTarget shipFollowTarget;
    public ShipFollowTarget ShipFollowTarget => shipFollowTarget;

    [SerializeField] protected ShootAbleObjectDameReceive shootAbleObjectDameReceive;
    public ShootAbleObjectDameReceive ShootAbleObjectDameReceive => shootAbleObjectDameReceive;

    [SerializeField] protected ShipShootByEnter shipShootByEnter;
    public ShipShootByEnter ShipShootByEnter => shipShootByEnter;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
        this.LoadShipFollowTarget();
        this.LoadshootAbleObjectDameReceive();
        this.LoadShipShootByEnter();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadShipShootByEnter()
    {
        this.shipShootByEnter = GetComponentInChildren<ShipShootByEnter>();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = this.transform.Find("Model");
        Debug.Log(transform.name +": LoadModel",gameObject);
    }

    protected virtual void LoadshootAbleObjectDameReceive()
    {
        if (this.shootAbleObjectDameReceive != null) return;
        this.shootAbleObjectDameReceive = GetComponentInChildren<ShootAbleObjectDameReceive>();

        Debug.Log(transform.name + ": LoadshootAbleObjectDameReceive", gameObject);
    }

    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();

        Debug.Log(transform.name + ": LoadObjLookAtTarget", gameObject);
    }

    protected virtual void LoadShipFollowTarget()
    {
        if (this.shipFollowTarget != null) return;
        this.shipFollowTarget = GetComponentInChildren<ShipFollowTarget>();

        Debug.Log(transform.name + ": LoadShipFollowTarget", gameObject);
    }


    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();

        Debug.Log(transform.name + ": LoadObjShooting", gameObject);
    }

    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();

        Debug.Log(transform.name + ": LoadObjMovement", gameObject);
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
