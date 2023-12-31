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
    [SerializeField] private TableHandler tableHandler; 

    public bool skipTutorial = false;

    public Action OnBeginGame;

    public AudioSource BGM;
    private bool gameBegun = false;
    [SerializeField] private CustomerHandler customerHandlerPrefab;
    [SerializeField] private TutorialView tutorialViewPrefab;

    public Level playingLevel;
    public Customer[] CustomerCollection;
    public Product[] DrinksCollection;
    public Container[] KebabCombination;
    public int[] MixturePrices;

    public RectTransform[] spotForCustomers;

    public GameUIMainView uiManager;
    public SoundController soundManager;
    

    public float countdownTime;
    private float currentTime;


    private int PlayerMoney = 1;
    private GameState gameState;

    public int customerCount { get; private set; }
    public CustomerHandler[] customersInGame = new CustomerHandler[2];

    [SerializeField] private CustomerHandler customerPrefab;

    public bool IsPaused = false;
    int minutes => Mathf.FloorToInt(currentTime / 60f);
    int seconds => Mathf.FloorToInt(currentTime % 60f);

    private int upsetCount, happyCount;

    private void Awake()
    {
        InvokeRepeating("SpawnRandomCustomer", 0f, 1.5f);

    }

    public void SetLevelConfig() 
    {
        countdownTime = (float)playingLevel.timeLimited;
        currentTime = countdownTime;

        playingLevel = GameSystem.Instance.LevelCollections.LevelGroups[GameSystem.Instance.PlayerLevel].level;
        overlayManager.gameObject.SetActive(true);
        overlayManager.SetActiveChildPanel<MissionPanel>();
        overlayManager.SetMissionDetail(playingLevel.moneyGoal, playingLevel.customerGoal, 0);
        overlayManager.SetPauseDetail(playingLevel.id);


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
        SetActiveCustomer();
        SetActiveGameTable();
    }

    private void Start()
    {
        
        SetLevelConfig();

    }


    private void SetActiveCustomer() 
    {
        uiManager.UpdateCustomerCount(customerCount.ToString(), playingLevel.customerGoal.ToString());
        spotForCustomers[0].gameObject.SetActive(true);

    }

    private void SetActiveGameTable() 
    {
        tableHandler.DisableAllShelves();
        tableHandler.DisapleMixtureInShelves();
        //print(playingLevel.id);
        for (int i = 0; i < playingLevel.MixtureShelfCollection.Length; i++)
        {
            tableHandler.SetActiveShelves(playingLevel.MixtureShelfCollection[i]);
        }
        for (int i = 0; i < playingLevel.MixtureCollection.Length; i++)
        {
            tableHandler.SetActiveProducts(playingLevel.MixtureCollection[i]);
        }
        for (int i = 0; i < playingLevel.DrinkCollection.Length; i++)
        {
            tableHandler.SetActiveDrinks(playingLevel.DrinkCollection[i]);

        }

        tableHandler.SetActivePlates(playingLevel.plate1Count, playingLevel.plate2Count);
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

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }

        }
    }

    public void Pause() 
    {
        if (IsPaused)
        {
            overlayManager.gameObject.SetActive(false);
            gameState = GameState.Game;
            overlayManager.DeactivatePanel<PausePanel>();
            IsPaused = false;
        }
        else
        {
            overlayManager.gameObject.SetActive(true);
            gameState = GameState.Pause;
            overlayManager.SetActiveChildPanel<PausePanel>();
            IsPaused = true;
        }
    }

    public void SetServedManager()
    {
        soundManager.Play2("coins collected4");
        customerCount++;
        happyCount++;
        uiManager.UpdateCustomerCount(customerCount.ToString(), playingLevel.customerGoal.ToString());
        CheckCustomerComplete();
    }

    public void SetTimeupCustormer() 
    {
        upsetCount++;
    }

    private void CheckLevelFailed() 
    {
    //angry face count, discard food count
    }

    public void SpawnRandomCustomer()
    {
        if (gameState == GameState.Summary)
        {
            return;
        }
        for (int i = 0; i < spotForCustomers.Length; i++)
        {

            if (i < playingLevel.MaxCudtomersQueue && !IsEarlyCustomer()) 
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
            else if (i > playingLevel.MaxCudtomersQueue) 
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
            overlayManager.SetSummaryDetail(PlayerMoney, customerCount, happyCount, upsetCount);

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

}
