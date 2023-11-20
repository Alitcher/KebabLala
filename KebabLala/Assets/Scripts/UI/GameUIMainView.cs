using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIMainView : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text customerCountText;
    [SerializeField] private Text customerGoalText;

    private void Start()
    {
        moneyText.text = GameSystem.PlayerLevel.ToString();
        levelText.text = GameSystem.PlayerLevel.ToString();
    }

    public void UpdateLevel()
    {
        levelText.text = GameSystem.PlayerLevel.ToString();

    }

    public void UpdateCustomerCount(string customerCount, string customerGoal) 
    {
        customerCountText.text = customerCount;
        customerGoalText.text = customerGoal;
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
