using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KebabLalaSystem : AliciaGenericSingleton<KebabLalaSystem>
{
    public Scenes CurrentScene => (Scenes)_currentScene.buildIndex; 
    Scene _currentScene => SceneManager.GetActiveScene();

    public int GetCurrentScene() 
    {
        return _currentScene.buildIndex;
    }
}

