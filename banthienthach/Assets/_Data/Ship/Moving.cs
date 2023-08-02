using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : DatMonoBehaviour
{

    protected Vector3 worldPosition;
    public float speed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {

        this.worldPosition = InputManager.Instance.MousePosition;
        this.worldPosition.z = 0;
        

        Vector3 newPos = Vector3.Lerp(transform.parent.position, worldPosition, this.speed);
        transform.parent.position = newPos;



    }
}
