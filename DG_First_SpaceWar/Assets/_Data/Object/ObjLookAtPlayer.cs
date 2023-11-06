using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjLookAtPlayer : ObjLookAtTarget
{

    [Header("ObjLookAtPlayer")]
    [SerializeField] protected GameObject player;
    

    // Update is called once per frame
    protected override void FixedUpdate()
    {

        this.GetMousePostition();
        base.FixedUpdate();



    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();

    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ":LoadPlayer ", gameObject);


    }


    protected virtual void GetMousePostition()
    {
        if (this.player == null) return;
        this.targetPostition = this.player.transform.position;

    }




}
