using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : ObjectDestroy
{
    protected override void FixedUpdate()
    {
        
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 20f)
        {
            ItemDropSpawner.Instance.Despawner(this.transform.parent);
        }

    }
}
