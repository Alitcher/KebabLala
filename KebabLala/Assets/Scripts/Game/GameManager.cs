using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AliciaGenericSingleton<GameManager>
{
    private bool gameBegun = false;
    [SerializeField] private CustomerHandler customerHandlerPrefab;
    [SerializeField] private GameObject[] newFoodInShelf;
    public Customer[] CustomerCollection;
    public Drink[] DrinksCollection;

    public RectTransform[] spotForCustomers;

    public UIManager uiManager;
    public SoundController soundManager;

    public float countdownTime = 60f;
    private float currentTime;

    public int PlayerLevel { get; private set; }

    private int PlayerMoney = 1;

    public int customerCount { get; private set; }
    public CustomerHandler[] customersInGame = new CustomerHandler[2];

    private bool triggerVeggie, triggerKebab;

    // public CustomerHandler[] customersPool = new CustomerHandler[6];

    [SerializeField] private CustomerHandler customerPrefab;
    int minutes => Mathf.FloorToInt(currentTime / 60f);
    int seconds => Mathf.FloorToInt(currentTime % 60f);

    private void Start()
    {
        currentTime = countdownTime;
        PlayerLevel = 0;

        InvokeRepeating("SpawnRandomCustomer", 0f, 2f);

        for (int i = 2; i < newFoodInShelf.Length; i++)
        {
            newFoodInShelf[i].gameObject.SetActive(false);
        }

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
                soundManager.Play("pop");

                customerCount++;
            }

        }

        CheckUpdateLevel();
    }

    private void CheckUpdateLevel() 
    {
        if (customerCount <= 4)
        {
            PlayerLevel = 1;
        }
        else if (customerCount > 4 && customerCount <= 8)
        {
            PlayerLevel = 2;
        }
        else if (customerCount > 8 && customerCount <= 15)
        {
            PlayerLevel = 3;
            if (!triggerVeggie) 
            {
                for (int i = 2; i < 6; i++)
                {
                    newFoodInShelf[i].gameObject.SetActive(true);
                }
                triggerVeggie = true;
                countdownTime += 20;
            }
        }
        else if (customerCount > 15 && customerCount <= 24)
        {
            PlayerLevel = 4;
        }
        else 
        {
            PlayerLevel = 5;
            if (!triggerKebab)
            {
                for (int i = 8; i < newFoodInShelf.Length; i++)
                {
                    newFoodInShelf[i].gameObject.SetActive(true);
                }
                triggerKebab = true;
                countdownTime += 20;
            }
        }

        uiManager.UpdateLevel();
    }

    //public void UpdateLevel() 
    //{
    //    PlayerLevel++;

    //}

    public void EarnMoney(int amount)
    {
        PlayerMoney += amount;
        uiManager.UpdateMoney(PlayerMoney);
        soundManager.Play2("coins collected4");

    }

    public int GetMoney()
    {
        return PlayerMoney;
    }

    public void BuyNewRecipe(int price) 
    {
        PlayerMoney -= price;
        uiManager.UpdateMoney(PlayerMoney);
        soundManager.Play("coins collected4");
    }
}
