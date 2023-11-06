using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    // Start is called before the first frame update
    private static JunkSpawner instance;

    public static JunkSpawner Instance { get => instance; }



    


    protected override void Awake()
    {
        base.Awake();

        JunkSpawner.instance = this;

    }


    public virtual Transform GetRandomBullet()
    {
        Transform cur = prefabs[Random.Range(0,prefabs.Count)];
        return cur;
    }


}
