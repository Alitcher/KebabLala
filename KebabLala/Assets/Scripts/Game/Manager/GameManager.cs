using Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameOverlayManager overlayManager;

    public bool skipTutorial = false;

    public Action OnBeginGame;

    public AudioSource BGM;
    private bool gameBegun = false;
    public GameObject[] IngredientShelves;
    [SerializeField] private CustomerHandler customerHandlerPrefab;
    [SerializeField] private TutorialView tutorialViewPrefab;

    public Level playingLevel;
    public Customer[] CustomerCollection;
    public Drink[] DrinksCollection;
    public Food[] KebabCombination;

    public RectTransform[] spotForCustomers;

    public GameUIMainView uiManager;
    public SoundController soundManager;
    

    public float countdownTime = 999f;//=> (float)playingLevel.timeLimited;
    private float currentTime;

    public int PlayerLevel { get; private set; }

    private int PlayerMoney = 1;
    private GameState gameState;


    public int customerCount { get; private set; }
    public CustomerHandler[] customersInGame = new CustomerHandler[2];

    private bool triggerVeggie, triggerKebab;

    // public CustomerHandler[] customersPool = new CustomerHandler[6];

    [SerializeField] private CustomerHandler customerPrefab;

    int minutes => Mathf.FloorToInt(currentTime / 60f);
    int seconds => Mathf.FloorToInt(currentTime % 60f);

    #region unused delete later
    private GameObject[] newFoodInShelf;
    #endregion

    private void Awake()
    {
        InvokeRepeating("SpawnRandomCustomer", 0f, 2f);

    }

    private void Start()
    {
        overlayManager.gameObject.SetActive(true);
        overlayManager.SetActiveChildPanel<MissionPanel>();
        overlayManager.SetMissionDetail(playingLevel.moneyGoal, playingLevel.customerGoal, 0);
        
        
        if (playingLevel.tutorialDB != null && !skipTutorial)
        {
            tutorialViewPrefab.gameObject.SetActive(true);
            gameState = GameState.Mission;
        }
        else
        {

            gameState = GameState.Game;
        }

        soundManager = GameObject.FindObjectOfType<SoundController>();
        currentTime = countdownTime;
        PlayerLevel = 0;
        uiManager.UpdateCustomerCount(customerCount.ToString(), playingLevel.customerGoal.ToString());

        spotForCustomers[0].gameObject.SetActive(true);
    }

    public void CheckTimeup()
    {
        BGM.Stop();
        soundManager.Play2("bell");
    }

    private void Update()
    {
        if (gameState == GameState.Game)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                // Countdown is finished, do something
                currentTime = 0f;
                CheckTimeup();

            }

            uiManager.UpdateCountdownText(minutes, seconds);

        }
    }

    public void SetServedManager()
    {
        soundManager.Play2("coins collected4");
        customerCount++;
        uiManager.UpdateCustomerCount(customerCount.ToString(), playingLevel.customerGoal.ToString());
        CheckCustomerComplete();
    }

    public void SpawnRandomCustomer()
    {
        if (gameState == GameState.Summary)
        {
            return;
        }
        for (int i = 0; i < spotForCustomers.Length; i++)
        {

            if (i <= playingLevel.MaxCudtomersQueue && !IsEarlyCustomer()) 
            {
                spotForCustomers[i].gameObject.SetActive(true);
            }
            if (!spotForCustomers[i].gameObject.activeSelf)
            {
                //assiming that the first elements are always active before their followings.
                break;
            }
            if (customersInGame[i] == null)
            {
                int index = UnityEngine.Random.Range(0, CustomerCollection.Length);
                customersInGame[i] = Instantiate(customerHandlerPrefab, spotForCustomers[i]);
                customersInGame[i].SetCustomerData(CustomerCollection[index]);
                customersInGame[i].name = CustomerCollection[index].name;
                customersInGame[i].gameObject.SetActive(true);
                soundManager.Play("pop");
            }
            else if (i > playingLevel.customersInQueue) 
            {
                spotForCustomers[i].gameObject.SetActive(false);
            }

        }
    }

    public bool IsCustomerComplete => (customerCount >= playingLevel.customerGoal);
    private void CheckCustomerComplete() 
    {
        if (IsCustomerComplete) 
        {
            gameState = GameState.Summary;
            soundManager.Play2("blink");
            BGM.Stop();
            overlayManager.gameObject.SetActive(true);
            overlayManager.SetActiveChildPanel<GameSummaryPanel>();
            overlayManager.SetSummaryDetail(PlayerMoney, customerCount, 0);

        }
    }

    public void increaseTime(float moreTime)
    {
        countdownTime += moreTime;
        currentTime = countdownTime + moreTime;
        uiManager.UpdateCountdownText(minutes, seconds);

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

    public bool IsEarlyCustomer() 
    {
        return customerCount < 2;
    }

    public bool allowKebabOrder() 
    {
        return playingLevel.MixtureCollection.Length > 0;
    }

    public void BuyNewRecipe(int price)
    {
        PlayerMoney -= price;
        uiManager.UpdateMoney(PlayerMoney);
        soundManager.Play("coins collected4");
    }

    public void ResetGameLevel() 
    {
    
    }

}
