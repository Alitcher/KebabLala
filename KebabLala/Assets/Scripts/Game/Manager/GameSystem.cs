using Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : AliciaGenericSingleton<GameSystem>
{
    public LevelCollection LevelCollections;
    public GameManager gameManager;
    public Action OnGameSceneActive;
    public static int PlayerLevel = 1;

    public override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayAtLevel(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayAtLevel(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayAtLevel(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayAtLevel(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayAtLevel(4);
        }
    }
    private void PlayAtLevel(int level)
    {
        SceneManager.LoadScene("Game");
        gameManager.SetLevelConfig();
        PlayerLevel = level;
    }

    internal void SetPlayingLevel(ref Level level, ref Tutorial tutorial)
    {
        if (KebabLalaSystem.Instance.GetCurrentScene() == 2)
        {

            gameManager.SetLevelConfig();
            //gameManager.SetGameField();
        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2) // Check if the loaded scene is your game scene
        {
            // Find the GameManager in the scene
            gameManager = GameObject.FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                //print("// Notify any listeners that the game scene is active");
                OnGameSceneActive?.Invoke();
            }
        }
    }
}
