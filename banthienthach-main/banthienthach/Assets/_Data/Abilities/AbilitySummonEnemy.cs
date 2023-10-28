using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [Header("Ability Summon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionsLimit = 2;


    protected override void FixedUpdate()
    {
       
        base.FixedUpdate();
        this.ClearDeadMinions();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }

    protected override void Summoning()
    {
        if (this.minions.Count >= minionsLimit) return;
        base.Summoning();
    }




    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;

        GameObject enemySpawner = GameObject.Find("EnemySpawner");

        this.spawner = enemySpawner.GetComponent<EnemySpawner>();

        Debug.Log(transform.name + ": LoadEnemySpawner()", gameObject);

    }

    protected override Transform Summon()
    {
        
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);
        return minion;
    }

    protected virtual void ClearDeadMinions()
    {
        /*foreach(Transform minion in this.minions)
        {
            if(minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);

                return;

            }
        }*/
    }

}
            