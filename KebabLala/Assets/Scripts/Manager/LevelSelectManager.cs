using Singleton;
using UnityEngine.SceneManagement;

public class LevelSelectManager : AliciaGenericSingleton<LevelSelectManager>
{
    public LevelCollection LevelCollections;
    private Level pendingLevel;
    private Tutorial pendingTutorial;
    private bool levelPending = false;

    public override void Awake()
    {
        GameSystem.Instance.OnGameSceneActive += OnGameSceneActive;
    }

    public void PlayAtLevel(int level)
    {
        // Store the level data temporarily
        pendingLevel = LevelCollections.LevelGroups[level].level;
        pendingTutorial = LevelCollections.LevelGroups[level].tutorial;
        levelPending = true;
        //SceneManager.LoadScene("Game"); // Load the game scene
    }

    private void OnGameSceneActive()
    {
        if (levelPending)
        {
            // Set the playing level now that the game scene is active
            GameSystem.Instance.SetPlayingLevel(ref pendingLevel, ref pendingTutorial);
            levelPending = false; // Reset the flag
        }
    }

    public void OpenUpgradePanel() { }

    public void OpenRecipePanel() { }
}
