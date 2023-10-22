using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIMainView : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text levelText;

    private void Start()
    {
        moneyText.text = GameManager.Instance.GetMoney().ToString();
        levelText.text = GameManager.Instance.PlayerLevel.ToString();
    }

    public void UpdateLevel()
    {
        levelText.text = GameManager.Instance.PlayerLevel.ToString();

    }

    public void UpdateMoney(int playerMoney) 
    {
        moneyText.text = playerMoney.ToString();
    }

    public void UpdateCountdownText(int mins, int secs)
    {
        string formattedTime = string.Format("{0:00}:{1:00}", mins, secs);
        timeText.text = formattedTime;
    }
}
