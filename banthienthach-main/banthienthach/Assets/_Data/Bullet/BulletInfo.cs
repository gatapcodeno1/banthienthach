using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : DatMonoBehaviour
{
    [SerializeField] protected Transform shooter;

    
    private static BulletInfo instance;

    public static BulletInfo Instance => instance;


    protected override void Awake()
    {
        base.Awake();
        BulletInfo.instance = this;

    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
    public virtual Transform GetShooter()
    {
        return shooter;
    }


}
