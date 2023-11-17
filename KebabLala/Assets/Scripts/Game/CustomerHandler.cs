using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerHandler : MonoBehaviour
{
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
    private int desiredFoodCount;

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
                desiredDrinkIcon[i].gameObject.SetActive(false);

                return true;

            }

        }
        return false;
    }

    public bool CheckProductMatch(ref GameObject[] ingre)
    {
        bool match = true;
        if (kebabPlate == null)
            match = false;
        for (int i = 0; i < ingre.Length; i++)
        {
            if (kebabPlate.transform.GetChild(i).gameObject.activeSelf != ingre[i].activeSelf)
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
        Destroy(kebabPlate.gameObject);

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

    private bool wantsKebab = false;
    private int kebabCount = 0;
    private int drinksCount = 0;


    private void SetCustomerData()
    {
        customerName = data.customerName;
        avatar.sprite = data.avatar;
        id = data.id;

        desiredFoodCount = GameSystem.Instance.gameManager.IsEarlyCustomer() ? 1 : Random.Range(1, GameSystem.Instance.gameManager.playingLevel.MaxOrder);
        drinksCount = GameSystem.Instance.gameManager.IsEarlyCustomer() ? desiredFoodCount : desiredFoodCount - Random.Range(1, desiredFoodCount);
        kebabCount = desiredFoodCount - drinksCount;

        
        desiredFoodId = new string[desiredFoodCount];

        desiredDrinkIcon = new Image[desiredFoodCount];

        int drinkId;
        for (int i = 0; i < desiredFoodCount; i++)
        {
            if (desiredDrinkIcon[i] == null)
            {
                desiredDrinkIcon[i] = Instantiate(productPrefab, BubbleBox);
                desiredDrinkIcon[i].name = desiredFoodId[i];

            }
            drinkId = Random.Range(0, GameSystem.Instance.gameManager.DrinksCollection.Length);
            desiredFoodId[i] = GameSystem.Instance.gameManager.DrinksCollection[drinkId].id;
            desiredDrinkIcon[i].sprite = GameSystem.Instance.gameManager.DrinksCollection[drinkId].avatar;
        }

        if (GameSystem.Instance.gameManager.allowKebabOrder())
        {
            wantsKebab = Random.Range(0, 2) == 0 ? false : true;
        }
        if (wantsKebab && kebabCount > 0)
        {
            print(kebabCount + " kebabs");
            SetKebabPlate();
        }

        waitingTime = data.waitingTime;
        reaction.gameObject.SetActive(false);
    }

    private void SetKebabPlate()
    {

        for (int i = 0; i < kebabCount; i++)
        {
            desiredFoodId[desiredFoodCount + i] = "";

        }

        kebabPlate = Instantiate(kebabPrefabData, BubbleBox);
        kebabPlate.name = "KebabPlate";
        kebabPlate.SetActiveIndredients();
        wantsKebab = false;
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

}
