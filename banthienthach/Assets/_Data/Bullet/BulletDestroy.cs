using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : ObjectDestroy
{
    protected override void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 50f)
        {
            GameObject.Destroy(transform.parent.gameObject);

        }

    }
}
