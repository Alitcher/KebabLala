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
    [SerializeField] private Image[] desiredFoodIcon;
    [SerializeField] private Image reaction;

    [SerializeField] private Slider WaitingBar;
    [SerializeField] private int tip;
    private int desiredFoodCount;

    public void DestroyThis() 
    {
        Destroy(this.gameObject, 2f);
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
                    GameManager.Instance.SetServedManager();
                    reaction.sprite = reactEmoji[0];
                    DestroyThis();

                }
                desiredFoodIcon[i].gameObject.SetActive(false);

                return true;

            }

        }
        return false;
    }

    public bool CheckProductMatch(ref GameObject[] ingre) 
    {
        bool match = true;
        if (kebabPlate == null)
            match =  false;
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
    private void SetCustomerData()
    {
        desiredFoodCount =  GameManager.Instance.customerCount < 4 ? 1 : Random.Range(1, 4);
        if (GameManager.Instance.PlayerLevel > 3)
        {
            wantsKebab = Random.Range(0, 2) == 0 ? false : true;
        }
        customerName = data.customerName;
        avatar.sprite = data.avatar;
        id = data.id;

        desiredFoodId = new string[desiredFoodCount];
        desiredFoodIcon = new Image[desiredFoodCount];

        int drinkId;
        for (int i = 0; i < desiredFoodCount; i++)
        {
            if (wantsKebab) 
            {
                kebabPlate = Instantiate(kebabPrefabData, BubbleBox);
                kebabPlate.name = "KebabPlate";
                kebabPlate.SetActiveIndredients();
                wantsKebab = false;
                continue;
            }
            if (desiredFoodIcon[i] == null)
            {
                desiredFoodIcon[i] = Instantiate(productPrefab, BubbleBox);
                desiredFoodIcon[i].name = desiredFoodId[i];

            }
            drinkId = Random.Range(0, GameManager.Instance.DrinksCollection.Length);
            desiredFoodId[i] = GameManager.Instance.DrinksCollection[drinkId].id;
            desiredFoodIcon[i].sprite = GameManager.Instance.DrinksCollection[drinkId].avatar;
        }
        reaction.gameObject.SetActive(false);
    }

    public void SetCustomerData(Customer _data)
    {
        data = _data;
        SetCustomerData();
    }

}
