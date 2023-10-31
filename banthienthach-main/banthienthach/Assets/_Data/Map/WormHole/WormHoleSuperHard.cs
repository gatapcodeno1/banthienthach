using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHoleSuperHard : DatMonoBehaviour
{

    protected string sceneName = "GamePlay_Super_Hard";

    protected virtual void OnMouseDown()
    {
        this.loadGalaxy();
    }
    protected virtual void loadGalaxy()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
