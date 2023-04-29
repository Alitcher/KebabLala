using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerHandler : MonoBehaviour
{
    [SerializeField] private BoxCollider2D colliderSelf;
    [SerializeField] private RectTransform BubbleBox;
    [SerializeField] private GameObject BubbleParent;
    [SerializeField] private Image productPrefab;

    [SerializeField] private Image avatar;
    [SerializeField] private Customer data;

    [SerializeField] private string customerName;
    [SerializeField] private string id;
    [SerializeField] private Sprite[] reactEmoji;
    [SerializeField] private string[] desiredFoodId;
    [SerializeField] private Image[] desiredFoodIcon;
    [SerializeField] private Image reaction;

    [SerializeField] private int tip;
    private int desiredFoodCount;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void DestroyThis() 
    {
        Destroy(this.gameObject, 3f);
    }

    public bool CheckProductMatch(string id)
    {
        for (int i = 0; i < desiredFoodCount; i++)
        {
            if (desiredFoodId[i] == null)
                continue;
            if (id == desiredFoodId[i])
            {
                desiredFoodId[i] = null;
                desiredFoodIcon[i].gameObject.SetActive(false);
                if (CheckGetAllProduct()) 
                {
                    reaction.sprite = reactEmoji[0];
                    DestroyThis();

                }
                return true;

            }
            else
            {
                print($"{desiredFoodId[i]} doesnt match {id}");
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

    private void SetCustomerData()
    {
        desiredFoodCount =  GameManager.Instance.customerCount < 4 ? 1 : Random.Range(1, 4);

        customerName = data.customerName;
        avatar.sprite = data.avatar;

        customerName = data.customerName;
        id = data.id;

        desiredFoodId = new string[desiredFoodCount];
        desiredFoodIcon = new Image[desiredFoodCount];

        int drinkId;
        for (int i = 0; i < desiredFoodCount; i++)
        {
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
        // desiredDrinks = new Image[]
    }

    public void SetCustomerData(Customer _data)
    {
        data = _data;
        SetCustomerData();
    }

}
