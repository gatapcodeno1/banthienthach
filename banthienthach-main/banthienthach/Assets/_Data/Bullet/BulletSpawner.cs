using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    // Start is called before the first frame update
    private static BulletSpawner instance;

    public static BulletSpawner Instance { get => instance; }

    
    public static string bulletTwo = "Bullet_2";
        
    

    protected override void Awake()
    {
        base.Awake();

        BulletSpawner.instance = this;

    }

    

}
