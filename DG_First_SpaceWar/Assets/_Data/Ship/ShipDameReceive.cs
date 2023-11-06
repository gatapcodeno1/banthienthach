using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipDameReceive : DameReceive
{


    
    public override void Reborn()
    {
        this.hpMax = 15000;
        base.Reborn();
    }

    protected override void LoadCollider()
    {
        base.LoadCollider();
        this.sphereCollider.radius = 0.37f;
    }

    protected override void Ondead()
    {
        Spawner.Despawner(transform.parent);
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);

    }

}
