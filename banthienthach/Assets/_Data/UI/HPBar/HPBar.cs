using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HPBar : DatMonoBehaviour
{
    [SerializeField] protected ShootAbleObjectCtrl shootAbleObjectCtrl;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected CameraHolder cameraHolder;
    [SerializeField] protected Spawner spawner;


    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadCameraHolder();
        this.LoadSpawner();
    }

    protected virtual void LoadSliderHP()
    {
        if (sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
        Debug.Log(transform.name + ": LoadSliderHP", gameObject);
    }

    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }


    protected virtual void LoadCameraHolder()
    {
        if (cameraHolder != null) return;
        this.cameraHolder = transform.GetComponent<CameraHolder>();
        Debug.Log(transform.name + ": LoadCameraHolder", gameObject);
    }


    public virtual void SetShootAbleObjectCtrl(ShootAbleObjectCtrl shootAbleObjectCtrl)
    {
        this.shootAbleObjectCtrl = shootAbleObjectCtrl;
    }


    protected virtual void HPShowing()
    {
        bool isDead = this.shootAbleObjectCtrl.ShootAbleObjectDameReceive.IsDead();
        if (isDead)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        if (this.shootAbleObjectCtrl == null) return;



        float hp = this.shootAbleObjectCtrl.ShootAbleObjectDameReceive.hp;
        float maxHp = this.shootAbleObjectCtrl.ShootAbleObjectDameReceive.hpMax;
        this.sliderHP.SetMaxHP(maxHp);
        this.sliderHP.SetCurrentHP(hp);

    }

    public virtual void SetTarget(Transform target)
    {
        this.cameraHolder.SetTarget(target);
    }

    

}
