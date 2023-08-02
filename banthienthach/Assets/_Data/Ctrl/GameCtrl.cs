using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : DatMonoBehaviour
{
    private static GameCtrl instance;

    public static GameCtrl Instance { get => instance;  }

    protected Camera mainCamera;

    public Camera MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.Log("only 1 GameCtrl to allow");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCamera();

    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;

        this.mainCamera = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + " :LoadCamera", gameObject);

    }




}
