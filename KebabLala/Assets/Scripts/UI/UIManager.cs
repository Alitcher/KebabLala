using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text moneyText;
    [SerializeField] private Text timeText;


    private void Start()
    {
        moneyText.text = GameManager.Instance.GetMoney().ToString();
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
