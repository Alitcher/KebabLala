using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverlayManager : MonoBehaviour
{
    [SerializeField] private PausePanel pausePanel;
    [SerializeField] private MissionPanel missionPanel;
    [SerializeField] private GameSummaryPanel gameSummaryPanel;

    private Dictionary<System.Type, Overlay> panelDictionary;
    
    private void Awake()
    {
        // Initialize the dictionary
        panelDictionary = new Dictionary<System.Type, Overlay>
        {
            { typeof(PausePanel), pausePanel },
            { typeof(MissionPanel), missionPanel },
            { typeof(GameSummaryPanel), gameSummaryPanel }
        };
    }

    public void SetActiveChildPanel<T>() where T : Overlay
    {
        foreach (var panelType in panelDictionary.Keys)
        {
            bool shouldActivate = panelType == typeof(T);
            panelDictionary[panelType].gameObject.SetActive(shouldActivate);
        }
    }
    public void DeactivatePanel<T>() where T : Overlay
    {
        this.gameObject.SetActive(false);
        if (panelDictionary.ContainsKey(typeof(T)))
        {
            panelDictionary[typeof(T)].gameObject.SetActive(false);
        }
    }

    public void SetMissionDetail(int income, int customerCount, int happyCount)
    {
        missionPanel.SetIncome(income.ToString());
        missionPanel.SetCustomersTotal(customerCount.ToString());
        missionPanel.SetHappyCustomersTotal(happyCount.ToString());
        missionPanel.SetLevel();
        Invoke("DeactivateMissionPanel", 3f);
    }

    public void SetSummaryDetail(int income, int customerCount, int happyCount, int upsetCount) 
    {
        gameSummaryPanel.SetIncome(income.ToString());
        gameSummaryPanel.SetCustomersTotal(customerCount.ToString());

        gameSummaryPanel.SetUpsetCustomersTotal(upsetCount > 0 ? upsetCount.ToString() : null);
        gameSummaryPanel.SetHappyCustomersTotal(happyCount > 0 ? happyCount.ToString() : null);

    }

    public void SetPauseDetail(string level)
    {
        pausePanel.SetLevelText(level);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Selection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
