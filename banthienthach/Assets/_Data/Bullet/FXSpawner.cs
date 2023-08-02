using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    // Start is called before the first frame update
    private static FXSpawner instance;

    public static FXSpawner Instance => instance;


    
    public static string smoke1 = "Smoke_1";
    public static string flash1 = "Flash_1";

    protected override void Awake()
    {
        base.Awake();

        FXSpawner.instance = this;

    }

    
}
