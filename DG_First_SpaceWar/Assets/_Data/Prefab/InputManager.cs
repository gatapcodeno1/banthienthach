using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputManager : MonoBehaviour
{


    private static InputManager instance;
    protected Vector3 mousePosition;
    [SerializeField] protected float onFiring;
    public static InputManager Instance { get => instance;  }

    public  Vector3 MousePosition { get => mousePosition; }

    [SerializeField] protected float onHoldRightMouse;
    public float OnHoldRightMouse => onHoldRightMouse;

    [SerializeField] protected float onTouchK;
    public float OnTouchK => onTouchK;

    protected Vector4 direction;

    public Vector4 Direction => direction;

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
        
    }

    void Update()
    {
        this.GetOnFiring();
        this.GetDirectionByKeyDown();
        this.GetOnHoldRightMouse();
        this.GetOnTouchK();
    }                               

    protected virtual void GetMousePos()
    {
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
    }

    protected virtual void GetDirectionByKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (this.direction.y == 0) this.direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (this.direction.z == 0) this.direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (this.direction.w == 0) this.direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;

        /*if (this.direction.x == 1) Debug.Log("Left");
        if (this.direction.y == 1) Debug.Log("Right");
        if (this.direction.z == 1) Debug.Log("Up");
        if (this.direction.w == 1) Debug.Log("Down");*/

    }

    protected virtual void GetOnFiring()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetOnHoldRightMouse()
    {
        this.onHoldRightMouse = Input.GetAxis("Submit");
    }
    protected virtual void GetOnTouchK()
    {
        
        this.onTouchK = Input.GetKeyDown(KeyCode.K) ? 1 : 0;
        if(onTouchK == 1)
        {
            Debug.Log("K"); 
        }
    }


}
