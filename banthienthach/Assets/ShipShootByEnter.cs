using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ShipShootByEnter : ObjShooting
{

    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnHoldRightMouse != 0;
        return this.isShooting;
    }

    
    protected override void Shooting()
    {
        bool b1 = false;
        timeShoot += Time.deltaTime;
        if (isShooting == false) return;

        if (timeShoot < timeDelay && b1 == false)
        {
            return;
        }
        else
        {
            b1 = true;
            timeShoot = 0;
        }
        if (b1 == true)
        {
            Vector3 pos = transform.position;
            quaternion ros = transform.rotation;
            Transform newBullet = SuperBulletSpawner.Instance.Spawn(SuperBulletSpawner.bulletOne, pos, ros);
            newBullet.GetComponentInChildren<BulletInfo>().SetShooter(transform.parent);
            newBullet.gameObject.SetActive(true);

            b1 = false;
        }

    }


}
