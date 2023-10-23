using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateHandler : MonoBehaviour
{
    public GameObject[] FoodCollection;
    [SerializeField] private GameObject clearBtn;
    // Start is called before the first frame update

    public void SetActiveCollection(string foodName)
    {
        for (int i = 0; i < FoodCollection.Length; i++)
        {
            if (foodName == FoodCollection[i].name)
            {
                FoodCollection[i].SetActive(true);
            }
        }
        clearBtn.SetActive(true);
    }

    public void ClearCollection()
    {
        GameManager.Instance.BuyNewRecipe(10);
        for (int i = 0; i < FoodCollection.Length; i++)
        {
            FoodCollection[i].SetActive(false);
        }
        clearBtn.SetActive(false);
    }
}
