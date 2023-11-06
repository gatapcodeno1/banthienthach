using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public abstract class ObjShooting : DatMonoBehaviour
{


    // Update is called once per frame

    
    public float timeDelay = 1f;
    public float timeShoot = 0f;
    public bool isShooting = false;
    
    //public Transform bulletPrefab;



    void Update()
    {
        this.IsShooting();
        Shooting();
        

    }
    
    protected virtual void Shooting()
    {
        bool b = false;
        timeShoot += Time.deltaTime;
        if (isShooting == false) return;
       
        if (timeShoot < timeDelay && b == false)
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
            quaternion ros = transform.rotation;
            /*  Transform newBullet =  Instantiate(bulletPrefab, pos,ros);*/
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo,pos, ros );
            newBullet.GetComponentInChildren<BulletInfo>().SetShooter(transform.parent);
            newBullet.gameObject.SetActive(true);
            b = false;
        }
        
    }


    protected abstract bool IsShooting();
        

}
