using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIncrease : DatMonoBehaviour
{

    [SerializeField] protected float maxLocalScale = 5f;
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void Awake()
    {
        bulletCtrl.BulletFly.gameObject.SetActive(false);
        base.Awake();
    }

    protected virtual void FixedUpdate()
    {


        if(InputManager.Instance.OnHoldRightMouse == 0)
        {
            bulletCtrl.BulletFly.gameObject.SetActive(true);
            shipCtrl.ObjShooting.gameObject.SetActive(true);
            shipCtrl.ObjMovement.gameObject.SetActive(true);
            shipCtrl.ObjLookAtTarget.gameObject.SetActive(true);
            return;
        }

        if (transform.parent.localScale.x > this.maxLocalScale)
        {
            bulletCtrl.BulletFly.gameObject.SetActive(true);
            shipCtrl.ObjShooting.gameObject.SetActive(true);
            shipCtrl.ObjMovement.gameObject.SetActive(true);
            shipCtrl.ObjLookAtTarget.gameObject.SetActive(true);

            return;
        }

        if (InputManager.Instance.OnHoldRightMouse == 1)
        {

            shipCtrl.ObjShooting.gameObject.SetActive(false);
            shipCtrl.ObjMovement.gameObject.SetActive(false);
            shipCtrl.ObjLookAtTarget.gameObject.SetActive(false);
            this.transform.parent.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadShipCtrl();
    }



    protected virtual void LoadBulletCtrl()
    {
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    protected virtual void LoadShipCtrl()
    {
        Transform ship = GameObject.Find("Ship").transform;
        this.shipCtrl = ship.transform.GetComponent<ShipCtrl>();
    }




}
