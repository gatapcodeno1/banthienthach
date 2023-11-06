using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDeSpawn : DespawnByTime
{

    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawner(transform.parent);
    }


}
