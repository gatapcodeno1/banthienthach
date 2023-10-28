using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public interface IObjAppearObserver
{
   public abstract void OnAppearStart();
   public abstract void OnAppearFinish();

}
