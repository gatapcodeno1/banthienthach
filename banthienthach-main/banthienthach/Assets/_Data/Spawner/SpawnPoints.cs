using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : DatMonoBehaviour
{

    public List<Transform> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {

        

        if (this.points.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);

    }

    protected override void Awake()
    {
        base.Awake();
        
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0,this.points.Count);
        return points[rand];
    }



   

}