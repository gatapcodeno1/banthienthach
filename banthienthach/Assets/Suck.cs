using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        Vector3 a = Vector3.Lerp(other.transform.parent.position, transform.position, Time.fixedDeltaTime * 0.7f);
        Debug.Log(other.transform.parent.name);
        other.transform.parent.position = a;
        

    }
}
