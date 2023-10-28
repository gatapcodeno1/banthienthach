using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectAppearBigger : ObjectAppearing
{
    [Header("ObjectAppearBigger")]
    
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
    [SerializeField] protected float speedScale = 0.01f;
   

    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitScale();
    }

   


    protected override void Appearing()
    {
        this.currentScale += this.speedScale;
        this.transform.parent.localScale = new Vector3(currentScale, currentScale, currentScale);
        if (this.currentScale >= this.maxScale) this.Appear();
        
    }


    protected virtual void InitScale()
    {
        this.transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
      
        
       
    }

    public override void Appear()
    {
       
        base.Appear();
        this.transform.parent.localScale = new Vector3(this.maxScale, this.maxScale, this.maxScale);
    }


}
