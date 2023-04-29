using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AliciaGenericSingleton<GameManager>
{
    [SerializeField] private CustomerHandler customerHandlerPrefab;
    public Customer[] CustomerCollection;
    public Drink[] DrinksCollection;

    public RectTransform[] spotForCustomers;

    public UIManager uiManager;


    public float countdownTime = 60f;
    private float currentTime;

    public static int PlayerLevel = 0;
    private int PlayerMoney = 0;

    public int customerCount { get; private set; }
    public CustomerHandler[] customersInGame = new CustomerHandler[2];

    // public CustomerHandler[] customersPool = new CustomerHandler[6];

    [SerializeField] private CustomerHandler customerPrefab;
    int minutes => Mathf.FloorToInt(currentTime / 60f);
    int seconds => Mathf.FloorToInt(currentTime % 60f);

    private void Start()
    {
        currentTime = countdownTime;
        InvokeRepeating("SpawnRandomCustomer", 0f, 2f);

    }
    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            // Countdown is finished, do something
            currentTime = 0f;
        }

        uiManager.UpdateCountdownText(minutes, seconds);
    }

    public void SpawnRandomCustomer()
    {
        for (int i = 0; i < spotForCustomers.Length; i++)
        {
            if (customersInGame[i] == null)
            {
                int index = Random.Range(0, CustomerCollection.Length);
                customersInGame[i] = Instantiate(customerHandlerPrefab, spotForCustomers[i]);
                customersInGame[i].SetCustomerData(CustomerCollection[index]);
                customersInGame[i].name = CustomerCollection[index].name;
                customersInGame[i].gameObject.SetActive(true);

                customerCount++;
            }

        }
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
