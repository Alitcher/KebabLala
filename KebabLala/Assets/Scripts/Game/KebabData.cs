using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabData : MonoBehaviour
{
    [SerializeField] private GameObject[] Ingredients;

    public void SetActiveIndredients() 
    {
        for (int i = 0; i < Ingredients.Length; i++)
        {
            if (Random.Range(0, 2) == 0) // 50% chance of being true
            {
                Ingredients[i].SetActive(true);
            }
            else
            {
                Ingredients[i].SetActive(false);
            }
        }
    }
}
