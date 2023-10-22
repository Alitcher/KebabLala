using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{

    public float countdownTime = 60f;
    private float currentTime;
    public GameUIMainView uiManager;

    private void Start()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            GameManager.Instance.CheckTimeup(); // Here we call the GameManager's CheckTimeup method.
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        uiManager.UpdateCountdownText(minutes, seconds);
    }
}
