using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected SpawnPoints spawnPoints;
  

    protected override void FixedUpdate()
    {
       
        
        base.FixedUpdate();
        this.Summoning();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void Summoning()
    {
        if (!this.isRead) return;
        this.Summon();
    }

    protected virtual void LoadSpawnPoints()
    {
        this.spawnPoints = Transform.FindObjectOfType<SpawnPoints>();
    }

    protected virtual Transform Summon()
    {
        Transform spawnPos = this.abilities.AbilityObjectCtrl.SpawnPoints.GetRandom();
        Transform minionPrefab = spawner.GetRandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab.name, spawnPos.position, spawnPos.rotation);
        minion.gameObject.SetActive(true);
        this.Active();
        return minion;
    }

    


}
