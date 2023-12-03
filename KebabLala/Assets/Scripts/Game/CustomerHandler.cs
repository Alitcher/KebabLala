using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Collections.Specialized.BitVector32;

public class CustomerHandler : MonoBehaviour
{
    [SerializeField] private string[] desiredFoodId;

    public KebabData KebabData => kebabPlate;
    [SerializeField] private KebabData kebabPlate;
    [SerializeField] private KebabData kebabPrefabData;

    [SerializeField] private BoxCollider2D colliderSelf;
    [SerializeField] private RectTransform BubbleBox;
    [SerializeField] private GameObject BubbleParent;
    [SerializeField] private Image productPrefab;

    [SerializeField] private Image avatar;
    [SerializeField] private Customer data;
    //[SerializeField] private Food kebabData;

    [SerializeField] private string customerName;
    [SerializeField] private string id;
    [SerializeField] private Sprite[] reactEmoji;

    [SerializeField] private Image[] desiredDrinkIcon;
    [SerializeField] private Image reaction;

    [SerializeField] private Slider WaitingBar;
    [SerializeField] private int tip;
    [SerializeField] private int desiredFoodCount;

    private Action OnEnableTimeUp;

    private bool isTimeup;

    public void DestroyThis()
    {
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        CountdownOrder();
    }

    public void Timeup()
    {
        if (WaitingBar.value <= 0)
        {
            BubbleParent.SetActive(false);
            reaction.sprite = reactEmoji[1];
            reaction.gameObject.SetActive(true);
            DestroyThis();
        }
    }

    public bool CheckProductMatch(string id, ref bool handed)
    {
        for (int i = 0; i < desiredFoodCount; i++)
        {
            if (desiredFoodId[i] == null)
                continue;
            if (id == desiredFoodId[i] && handed)
            {
                desiredFoodId[i] = null;
                if (CheckGetAllProduct())
                {
                    GameSystem.Instance.gameManager.SetServedManager();
                    reaction.sprite = reactEmoji[0];
                    DestroyThis();

                }

                if (desiredDrinkIcon.Length >= i && desiredDrinkIcon[i] != null)
                {
                    BubbleBox.transform.GetChild(i).gameObject.SetActive(false);
                    desiredDrinkIcon[i] = null;//.gameObject.SetActive(false);
                }


                return true;

            }

        }
        return false;
    }

    private bool CheckGetAllProduct()
    {
        bool getAll = true;
        for (int i = 0; i < desiredFoodCount; i++)
        {
            if (desiredFoodId[i] != null)
                getAll = false;

        }


        BubbleParent.SetActive(!getAll);
        colliderSelf.enabled = !getAll;
        reaction.gameObject.SetActive(getAll);

        return getAll;
    }

    [SerializeField] private int kebabCount = 0;
    [SerializeField] private int drinksCount = 0;


    public bool wantsKebab()
    {
        return UnityEngine.Random.Range(0, 2) == 0;
    }

    int startDrinkElement;

    private void SetCustomerData()
    {
        customerName = data.customerName;
        avatar.sprite = data.avatar;
        id = data.id;

        drinksCount = GameSystem.Instance.gameManager.IsEarlyCustomer() ? 1 : UnityEngine.Random.Range(1, GameSystem.Instance.gameManager.playingLevel.MaxOrder);
        kebabCount = (GameSystem.Instance.gameManager.IsEarlyCustomer() || GameSystem.PlayerLevel == 0) ? 0 : 1;

        desiredFoodCount = drinksCount + kebabCount;

        desiredFoodId = new string[desiredFoodCount];
        desiredDrinkIcon = new Image[desiredFoodCount];

        for (int i = 0; i < kebabCount; i++)
        {
            SetKebabPlate(ref desiredFoodId[i]);
            desiredFoodId[i] = kebabPlate.kebabData.id;
            kebabPlate.name = desiredFoodId[i];
        }

        int drinkId;
        startDrinkElement = (kebabCount == 0) ? 0 : kebabCount;
        for (int i = 0; i < drinksCount; i++)
        {
            drinkId = UnityEngine.Random.Range(0, GameSystem.Instance.gameManager.DrinksCollection.Length);
            desiredFoodId[startDrinkElement + i] = GameSystem.Instance.gameManager.DrinksCollection[drinkId].id;

            if (desiredDrinkIcon[startDrinkElement + i] == null)
            {
                desiredDrinkIcon[startDrinkElement + i] = Instantiate(productPrefab, BubbleBox);
                desiredDrinkIcon[startDrinkElement + i].name = desiredFoodId[startDrinkElement + i];

            }

            desiredDrinkIcon[startDrinkElement + i].sprite = GameSystem.Instance.gameManager.DrinksCollection[drinkId].avatar;


        }


        reaction.gameObject.SetActive(false);
    }

    private void SetKebabPlate(ref string id)
    {
        kebabPlate = Instantiate(kebabPrefabData, BubbleBox);
        kebabPlate.SetActiveIndredients();
        kebabPlate.name = id;

        id = kebabPlate.kebabData.id;

    }

    public void SetCustomerData(Customer _data)
    {
        OnEnableTimeUp += Timeup;
        data = _data;
        SetCustomerData();
    }

    [SerializeField] private Image fillImage;
    private void SetSliderColor()
    {
        if (WaitingBar.value < 0.2f)
        {
            //WaitingBar.colors.normalColor = Color.Lerp(Color.red, Color.green, WaitingBar.value / 20);
        }
    }

    private void CountdownOrder()
    {
        if (isTimeup) 
        {
            return;
        }

        WaitingBar.value -= Time.deltaTime * GameSystem.Instance.gameManager.playingLevel.timeSlack;
        fillImage.color = Color.Lerp(Color.red, Color.green, WaitingBar.value / WaitingBar.maxValue);
        if (WaitingBar.value <= 0)
        {
            OnEnableTimeUp.Invoke();
            isTimeup = true;
        }
    }

    internal void SetKebabHanded()
    {
        desiredFoodId[0] = null;
        if (CheckGetAllProduct())
        {
            GameSystem.Instance.gameManager.SetServedManager();
            reaction.sprite = reactEmoji[0];
            DestroyThis();
        }
    }
}
