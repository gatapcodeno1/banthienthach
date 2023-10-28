using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public abstract class Spawner : DatMonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected List<Transform> prefabs;

    [SerializeField] protected List<Transform> poolObjects;

    [SerializeField] protected Transform holder;





    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefab();
        this.LoadHolder();
    }

    protected virtual void LoadPrefab()
    {


        if(this.prefabs.Count > 0) { return; }

        Transform prefabObj = transform.Find("Prefab");

        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.Hideprefab();

        Debug.Log(transform.name + ":LoadPrefabs", gameObject);

    }


    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;

        this.holder = GetComponentInChildren<Holder>().transform;

        Debug.Log(transform.name + "LoadHolder", gameObject);
         

    }


    protected virtual void Hideprefab()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual void Despawner(Transform obj)
    {
        this.poolObjects.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform Spawn(string bulletname , Vector3 spawnpos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabbyname(bulletname);
        if(prefab == null)
        {
            Debug.LogWarning("Prefab not found" + prefab);
            return null;
        }
        Transform newPrefab =  GetObjectFromPool(prefab);
        newPrefab.transform.rotation = rotation;
        newPrefab.transform.position = spawnpos;
        newPrefab.parent = this.holder;

        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in poolObjects)
        {
            if(poolObj.name == prefab.name)
            {
                this.poolObjects.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;

    }

    public virtual Transform GetPrefabbyname(string bulletname)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == bulletname)
            {
                return prefab;
            }
        }
        return null;
    }


    public virtual Transform GetRandomPrefab()
    {        
        return prefabs[UnityEngine.Random.Range(0,prefabs.Count - 1)];
    }
    
}
