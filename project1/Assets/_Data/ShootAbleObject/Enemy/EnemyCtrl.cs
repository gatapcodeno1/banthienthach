using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ShootAbleObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
