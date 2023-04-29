using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AliciaGenericSingleton<GameManager>
{
    public Customer[] CustomerCollection;
    public Drink[] DrinksCollection;

    public RectTransform[] spotForCustomers;

    public UIManager uiManager;

    public float countdownTime = 60f;
    private float currentTime;

    public static int PlayerLevel = 0;
    private int PlayerMoney = 0;

    public CustomerHandler[] customersInGame;

    int minutes => Mathf.FloorToInt(currentTime / 60f);
    int seconds => Mathf.FloorToInt(currentTime % 60f);

    private void Start()
    {
        currentTime = countdownTime;

    }
    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            // Countdown is finished, do something
            currentTime = 0f;
        }

        uiManager.UpdateCountdownText(minutes,seconds);
    }

    public void SpawnRandomCustomer() 
    {
    
    }

    public void EarnMoney(int amount)
    {
        PlayerMoney += amount;
        uiManager.UpdateMoney(PlayerMoney);
    }

    public int GetMoney() 
    {
        return PlayerMoney;
    }
}
