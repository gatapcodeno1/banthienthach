using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoDestroy : ObjectDestroy
{

    protected override void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 30f)
        {
            JunkSpawner.Instance.Despawner(transform.parent);
        }


    }

}
