using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : DatMonoBehaviour
{
    [Header("BaseSlider")]
    [SerializeField] protected Slider slider;


    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }

    protected virtual void FixedUpdate()
    {

    }

    protected virtual void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected abstract void OnChanged(float newValue);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }



    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider ", gameObject);
    }
}
