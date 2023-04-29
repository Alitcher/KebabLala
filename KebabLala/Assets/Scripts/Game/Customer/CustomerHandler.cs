using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerHandler : MonoBehaviour
{
    [SerializeField] private Image avatar;
    [SerializeField] private Customer data;

    [SerializeField] private string customerName;
    [SerializeField] private string id;
    [SerializeField] private Sprite[] reactEmoji;
    [SerializeField] private string[] desiredFoodId;
    [SerializeField] private Image[] desiredFoodIcon;

    [SerializeField] private int tip;

    private int desiredFoodCount;

    // Start is called before the first frame update
    void Start()
    {

        data = GameManager.Instance.CustomerCollection[Random.Range(0, GameManager.Instance.CustomerCollection.Length)];
        customerName = data.customerName;
        id = data.id;

        desiredFoodCount = Random.Range(0, 3);
        desiredFoodId = new string[desiredFoodCount];
        desiredFoodIcon = new Image[desiredFoodCount];

        for (int i = 0; i < desiredFoodCount; i++)
        {
            desiredFoodId[i] = GameManager.Instance.DrinksCollection[Random.Range(0, GameManager.Instance.DrinksCollection.Length)].id;

        }
    }

    public void SetCustomerData() 
    {
        customerName = data.customerName;
        avatar.sprite = data.avatar;
       // desiredDrinks = new Image[]
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
