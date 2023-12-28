using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkState : IProductState
{
    public void SetSellPrice(MixtureNode mixtureNode)
    {
        // Implementation for Drink
    }

    public void UpdateNewPrice(MixtureNode mixtureNode)
    {
        // Implementation for Drink
    }

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
        return ProductsManager.Instance.GetDrinkUpgradePrice(whichShelf).ToString();
    }

    public void UpdateLevel(int whichShelf, int currentLevel) 
    {
        ProductsManager.Instance.UpdateDrinkLevel(whichShelf, currentLevel);
    }
}