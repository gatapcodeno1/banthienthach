using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : MonoBehaviour
{
    protected string sceneName = "GamePlay";

    protected virtual void OnMouseDown()
    {
        this.loadGalaxy();
    }
    protected virtual void loadGalaxy()
    {
        SceneManager.LoadScene(sceneName);
    }
}
