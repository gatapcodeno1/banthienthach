using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public override Transform Spawn(string bulletname, Vector3 spawnpos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(bulletname, spawnpos, rotation);
        this.AddHPBar2Obj(newEnemy);

        return newEnemy;

    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootAbleObjectCtrl shootAbleObjectCtrl = newEnemy.GetComponent<ShootAbleObjectCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);

        HPBar hPBar = newHPBar.GetComponent<HPBar>();
        hPBar.SetShootAbleObjectCtrl(shootAbleObjectCtrl);

        hPBar.SetTarget(newEnemy);

        newHPBar.gameObject.SetActive(true);

    }

}
