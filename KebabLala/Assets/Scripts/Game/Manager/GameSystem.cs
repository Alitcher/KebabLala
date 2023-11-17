using Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : AliciaGenericSingleton<GameSystem>
{
    public GameManager gameManager;
    public Action OnGameSceneActive;

    public override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    internal void SetPlayingLevel(ref Level level, ref Tutorial tutorial)
    {
        if(KebabLalaSystem.Instance.GetCurrentScene() == 2)
            gameManager.playingLevel = level;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2) // Check if the loaded scene is your game scene
        {
            // Find the GameManager in the scene
            gameManager = GameObject.FindObjectOfType<GameManager>();
            print("OnSceneLoaded");
            if (gameManager != null)
            {
                print("// Notify any listeners that the game scene is active");
                OnGameSceneActive?.Invoke();
            }
        }
    }
}
