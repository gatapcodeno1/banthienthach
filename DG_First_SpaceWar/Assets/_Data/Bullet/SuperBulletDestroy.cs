using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBulletDestroy : ObjectDestroy
{
    protected override void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 50f)
        {
            SuperBulletSpawner.Instance.Despawner(transform.parent);
        }

    }
}
