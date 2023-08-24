using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{


    private static InputManager instance;
    protected Vector3 mousePosition;
    [SerializeField] protected float onFiring;
    public static InputManager Instance { get => instance;  }

    public  Vector3 MousePosition { get => mousePosition; }

    public float OnFiring => onFiring;

    private void Awake()
    {
        if(InputManager.Instance!= null)
        {
            Debug.Log("Only 1 InputManager");
        }
        InputManager.instance = this;
    }
    // Start is called before the first frame update
    void FixedUpdate()
    {
        GetMousePos();
        GetOnFiring();
    }


    protected virtual void GetMousePos()
    {
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
    }

    protected virtual void GetOnFiring()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

}
