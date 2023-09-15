using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,Camera.main.transform.position) > 20f)
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }
}
