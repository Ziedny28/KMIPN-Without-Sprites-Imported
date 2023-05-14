using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool isGamePaused = false;
    public void OnClickPause()
    {
        Time.timeScale = 0;
    }

    public void OnClickUnpause()
    {
        Time.timeScale = 1;
    }

    public void IsGamePaused()
    {
        if (Time.timeScale == 0) 
        {
            isGamePaused = true;
        }
        else 
        {
            isGamePaused = false;
        }
    }

    public void OnClickQuit() 
    {
        
    }
}
