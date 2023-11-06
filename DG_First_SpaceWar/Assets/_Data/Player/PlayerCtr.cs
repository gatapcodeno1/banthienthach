using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : DatMonoBehaviour
{
    private static PlayerCtr instance;
    public static PlayerCtr Instance => instance;


    public ShipCtrl currentShip;
    public ShipCtrl CurrentShip => currentShip;

    public PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    protected override void Awake()
    {
        base.Awake();

        if (PlayerCtr.instance != null) Debug.LogError("Only 1 PlayerCtrl allow exist");
        PlayerCtr.instance = this;

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickup();
        this.LoadCurrentShip();
    }

    protected virtual void LoadPlayerPickup()
    {
        if (this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup", gameObject);
    }

    protected virtual void LoadCurrentShip()
    {
        if (this.currentShip != null) return;
        this.currentShip = GameObject.Find("Ship").GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadCurrentShip", gameObject);
    }


}
