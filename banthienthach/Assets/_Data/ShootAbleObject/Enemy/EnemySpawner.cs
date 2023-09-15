using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    // Start is called before the first frame update
    private static EnemySpawner instance;

    public static EnemySpawner Instance { get => instance; }

    public Transform holder;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.Log("Only 1 EnemySpawner");
        EnemySpawner.instance = this;

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        this.holder = GameObject.Find("Holder").transform;
    }

    public virtual Transform GetRandomBullet()
    {
        Transform cur = prefabs[Random.Range(0, prefabs.Count)];
        return cur;
    }

}
