using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : DatMonoBehaviour
{
    public SpawnCtrl spawnCtrl;
    public float randomDelay = 1f;
    public float randomTimer = 0f;
    public float randomLimit = 3f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.spawnCtrl != null) return;
        this.spawnCtrl = GetComponent<SpawnCtrl>();
        Debug.Log(transform.name + ": JunkCtrl", gameObject);

    }

    protected virtual void FixedUpdate()
    {
        
        JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        
        this.randomTimer += Time.fixedDeltaTime;

        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform ranPoint = this.spawnCtrl.spawnPoints.GetRandom();


        Vector3 pos = ranPoint.position;
        Quaternion ros = transform.rotation;
        Transform ran = EnemySpawner.Instance.GetRandomBullet();
        Transform obj = this.spawnCtrl.spawner.Spawn(ran.name,pos,ros);
        obj.gameObject.SetActive(true);
        
    }

    
}
