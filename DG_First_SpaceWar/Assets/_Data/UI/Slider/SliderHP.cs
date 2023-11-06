using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SliderHP : BaseSlider
{
    [Header("SlideHP")]
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 100;
    protected override void OnChanged(float newValue)
    {
        //Debug.Log("NewValue: "+ newValue);        
    }

    protected override void FixedUpdate()
    {
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
    }

    public virtual void SetMaxHP(float maxHP) {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP = currentHP; 
    }



}
