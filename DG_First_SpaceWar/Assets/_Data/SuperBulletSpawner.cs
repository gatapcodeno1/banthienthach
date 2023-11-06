using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBulletSpawner : Spawner
{
    // Start is called before the first frame update
    private static SuperBulletSpawner instance;

    public static SuperBulletSpawner Instance { get => instance; }


    public static string bulletOne = "Bullet_1";



    protected override void Awake()
    {
        base.Awake();

        SuperBulletSpawner.instance = this;

    }
}
