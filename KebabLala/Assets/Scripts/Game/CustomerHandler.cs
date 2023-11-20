using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerHandler : MonoBehaviour
{
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
    [SerializeField] private string[] desiredFoodId;
    [SerializeField] private Image[] desiredDrinkIcon;
    [SerializeField] private Image reaction;

    [SerializeField] private Slider WaitingBar;
    [SerializeField] private int tip;
    [SerializeField] private int desiredFoodCount;

    private float waitingTime;

    public void DestroyThis()
    {
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        CountdownOrder();
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

                if(desiredDrinkIcon.Length >= i && desiredDrinkIcon[i]!= null)
                desiredDrinkIcon[i].gameObject.SetActive(false);

                return true;

            }

        }
        return false;
    }

    public bool CheckProductMatch(GameObject[] ingre)
    {
        bool match = true;
        if (kebabPlate == null)
        {
            match = false;
        }

        for (int i = 0; i < ingre.Length; i++)
        {
            if (!kebabPlate.Mixtures[i].activeSelf)
            {
                continue;
            }
            if (kebabPlate.Mixtures[i].name != ingre[i].name)
            {
                match = false;
                return match;
            }
        }
        if (CheckGetAllProduct())
        {
            reaction.sprite = reactEmoji[0];
            DestroyThis();
        }
        kebabPlate.gameObject.SetActive(false);

        return match;
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
        return Random.Range(0, 2) == 0;
    }
    int startDrinkElement;
    private void SetCustomerData()
    {
        customerName = data.customerName;
        avatar.sprite = data.avatar;
        id = data.id;

        drinksCount = GameSystem.Instance.gameManager.IsEarlyCustomer() ? 1 : Random.Range(1, GameSystem.Instance.gameManager.playingLevel.MaxOrder);
        kebabCount = (GameSystem.Instance.gameManager.IsEarlyCustomer()) ? 0 : 1;//(!wantsKebab()) ? 0 : 1;//Random.Range(1, GameSystem.Instance.gameManager.playingLevel.MaxOrder);

        desiredFoodCount = drinksCount + kebabCount;

        desiredFoodId = new string[desiredFoodCount];
        desiredDrinkIcon = new Image[desiredFoodCount];

        for (int i = 0; i < kebabCount; i++)
        {
            print($"drinksCount{drinksCount},kebabCount{kebabCount},desiredFoodCount{desiredFoodCount}");
            SetKebabPlate(ref desiredFoodId[i]);
            desiredFoodId[i] = kebabPlate.kebabData.id;
        }

        int drinkId;
        startDrinkElement = (kebabCount == 0) ? 0 : kebabCount;
        for (int i = 0; i < drinksCount; i++)
        {
            drinkId = Random.Range(0, GameSystem.Instance.gameManager.DrinksCollection.Length);
            desiredFoodId[startDrinkElement + i] = GameSystem.Instance.gameManager.DrinksCollection[drinkId].id;

            if (desiredDrinkIcon[i] == null)
            {
                desiredDrinkIcon[i] = Instantiate(productPrefab, BubbleBox);
                desiredDrinkIcon[i].name = desiredFoodId[startDrinkElement];

            }

            desiredDrinkIcon[i].sprite = GameSystem.Instance.gameManager.DrinksCollection[drinkId].avatar;


        }




        waitingTime = data.waitingTime;
        reaction.gameObject.SetActive(false);
    }

    private void SetKebabPlate(ref string id)
    {
        kebabPlate = Instantiate(kebabPrefabData, BubbleBox);
        kebabPlate.SetActiveIndredients();
        kebabPlate.name = "KebabPlate";

        id = kebabPlate.kebabData.id;

    }

    public void SetCustomerData(Customer _data)
    {
        data = _data;
        SetCustomerData();
    }

    private void CountdownOrder()
    {
        WaitingBar.value -= Time.deltaTime * GameSystem.Instance.gameManager.playingLevel.timeSlack;
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
