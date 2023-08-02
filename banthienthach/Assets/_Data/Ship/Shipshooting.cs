using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shipshooting : MonoBehaviour
{


    // Update is called once per frame

    
    public float timeDelay = 1f;
    public float timeShoot = 0f;

    public Transform bulletPrefab;

    void FixedUpdate()
    {
        Shooting();
        

    }
    bool b = false;
    protected virtual void Shooting()
    {

        

        timeShoot += Time.deltaTime;

        if(timeShoot < timeDelay && b == false)
        {
            return;
        }
        else
        {
            b = true;
            timeShoot = 0;
        }
        

        if (b == true)
        {



            Vector3 pos = transform.position;
            pos.y += 0.3f;
            quaternion ros = transform.rotation;
           

            float a = Input.GetAxis("Fire1");
            if (a != 1) return;
            /*  Transform newBullet =  Instantiate(bulletPrefab, pos,ros);*/

            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo,pos, ros );
            BulletSpawner.Instance.shooter = transform.parent;

            if (newBullet == null)
            {
                return;
            }

            

            newBullet.gameObject.SetActive(true);
            
            b = false;

        }
       




    }

}
