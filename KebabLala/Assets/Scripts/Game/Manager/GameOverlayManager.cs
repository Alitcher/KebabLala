using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
