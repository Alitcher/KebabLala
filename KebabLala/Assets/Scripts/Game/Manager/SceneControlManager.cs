using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlManager : AliciaGenericSingleton<SceneControlManager>
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LevelSelection() 
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Pause(bool isPaused)
    {
        Time.timeScale = (isPaused) ? 1.0f : 0.0f;
    }


}
