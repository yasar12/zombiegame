using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    
    public void reloadgame() {

        SceneManager.LoadScene(0);
        Debug.Log("hi");
        Time.timeScale = 1.0f;
    }
    public void quitgame() 
    { 
    Application.Quit();
    }
}
