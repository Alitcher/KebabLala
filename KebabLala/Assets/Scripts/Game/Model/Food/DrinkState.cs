using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkState : IProductState
{
    public string GetUpgradePrice(int whichShelf) 
    {
        return ProductsManager.Instance.GetDrinkUpgradePrice(whichShelf).ToString();
    }

    public string GetCurrentPrice(int whichShelf)
    {
        return ProductsManager.Instance.GetDrinkUpgradePrice(whichShelf).ToString();
    }

    public string GetNextPrice(int whichShelf)
    {
        return ProductsManager.Instance.GetDrinkNextPrice(whichShelf).ToString();
    }

    public void UpdateLevel(int whichShelf, int currentLevel) 
    {
        ProductsManager.Instance.UpdateDrinkLevel(whichShelf, currentLevel);
    }

    public string LevelLog(int whichShelf)
    {
        return $"{ProductsManager.Instance.DrinkValues.GetValue(whichShelf)} Level = {PlayerPrefs.GetInt(ProductsManager.Instance.MixtureValues.GetValue(whichShelf).ToString())})";
    }
}