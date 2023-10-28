using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
    // Start is called before the first frame update
    private static MotherShipSpawner instance;

    public static MotherShipSpawner Instance { get => instance; }

    

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null) Debug.Log("Only 1 MotherShipSpawner");
        MotherShipSpawner.instance = this;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
    }

    

    public virtual Transform GetRandomBullet()
    {
        Transform cur = prefabs[Random.Range(0, prefabs.Count)];
        return cur;
    }

}
