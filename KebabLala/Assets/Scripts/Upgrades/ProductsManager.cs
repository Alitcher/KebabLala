using Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsManager : AliciaGenericSingleton<ProductsManager>
{
    public const int maxLevel = 3;
    public ProductStatCollectionTable ProductStatCollection;
    public int[] DrinksCurrentLevel;
    public int[] MixtureCurrentLevel;
    public int PlateLevel;

    Array drinkValues = Enum.GetValues(typeof(DrinkList));
    Array mixtureValues = Enum.GetValues(typeof(ProductList));

    public override void Awake()
    {
        base.Awake();
        InitProducts();
    }

    public void InitProducts()
    {
        SetProductLevel();

    }

    public int GetMixtureUpgradePrice(int productIndex)
    {
        return ProductStatCollection.MixturesList[productIndex].buy[MixtureCurrentLevel[productIndex]];
    }

    public int GetDrinkUpgradePrice(int productIndex)
    {
        return ProductStatCollection.DrinksList[productIndex].buy[DrinksCurrentLevel[productIndex]];
    }

    public int GetMixturePrice(int productIndex)
    {
        return ProductStatCollection.MixturesList[productIndex].sell[MixtureCurrentLevel[productIndex]];
    }

    public int GetDrinkPrice(int productIndex)
    {
        return ProductStatCollection.MixturesList[productIndex].sell[DrinksCurrentLevel[productIndex]];
    }

    public int GetDrinkNextPrice(int productIndex)
    {
        if (CheckMax(DrinksCurrentLevel[productIndex] + 1, maxLevel)) 
        {
            return 0;
        }

        return ProductStatCollection.MixturesList[productIndex].sell[DrinksCurrentLevel[productIndex] + 1];
    }

    public int GetMixtureNextPrice(int productIndex)
    {
        if (CheckMax(MixtureCurrentLevel[productIndex] + 1, maxLevel))
        {
            return 0;
        }

        return ProductStatCollection.MixturesList[productIndex].sell[MixtureCurrentLevel[productIndex] + 1];
    }


    private void SetProductLevel()
    {

        for (int i = 0; i < DrinksCurrentLevel.Length; i++)
        {
            DrinksCurrentLevel[i] = PlayerPrefs.GetInt(drinkValues.GetValue(i + 1).ToString());
        }

        for (int i = 0; i < MixtureCurrentLevel.Length; i++)
        {
            MixtureCurrentLevel[i] = PlayerPrefs.GetInt(mixtureValues.GetValue(i + 1).ToString());
        }
    }

    public void UpdateMixtureLevel(int mixtureIndex, int currentLevel)
    {
        MixtureCurrentLevel[mixtureIndex] = currentLevel;
    }

    public void UpdateDrinkLevel(int drinkIndex, int currentLevel)
    {
        DrinksCurrentLevel[drinkIndex] = currentLevel;
    }

    public void ResetMixtureLevel()
    {
        int length = mixtureValues.Length;

        for (int i = 1; i < length; i++)
        {
            string name = mixtureValues.GetValue(i).ToString();
            PlayerPrefs.SetInt(name, 0);
        }
    }

    private bool CheckMax(int nextLevel, int maxLevel)
    {
        return (nextLevel >= maxLevel);
    }
}
