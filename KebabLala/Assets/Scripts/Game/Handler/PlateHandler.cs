using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlateHandler : MonoBehaviour
{
    public KebabData kebabData;
    public GameObject[] FoodCollection;
    public int[] prices;
    [SerializeField] private Button clearBtn;
    [SerializeField] private int platePrice;

    public int KebabPlatePrice => 50 + MixturesPrices; 
    public int MixturesPrices = 0;

    public string id { get; private set; }

    // call this function when the player drag an ingredient(aka mixture) into the plate. the total number of ingredients in plate is fixed which is mixture[9]
    public void SetActiveCollection(string foodName)
    {
        StringBuilder idBuilder = new StringBuilder(id);
        for (int i = 0; i < FoodCollection.Length; i++) // FoodCollection is also called mixture
        {
            if (foodName == FoodCollection[i].name)
            {
                FoodCollection[i].SetActive(true);
                if (idBuilder.Length > i) // Make sure the StringBuilder has enough characters
                {
                    idBuilder[i] = '1';
                    MixturesPrices += ProductsManager.Instance.GetMixturePrice(i);
                }
            }
        }
        id = idBuilder.ToString();
        clearBtn.gameObject.SetActive(true);
    }

    public void GetMixturePrice(ProductType type) 
    {
    
    }

    public void ClearCollection()
    {
        //GameSystem.Instance.gameManager.BuyNewRecipe(10);
        for (int i = 0; i < FoodCollection.Length; i++)
        {
            FoodCollection[i].SetActive(false);
        }

        clearBtn.gameObject.SetActive(false);
        id = new String('0', FoodCollection.Length); // Assuming FoodCollection.Length is 9 // the default value when the plate is empty
    }

    public void SetButtonAppearance() 
    {
        clearBtn.gameObject.SetActive(true);
    }

}
