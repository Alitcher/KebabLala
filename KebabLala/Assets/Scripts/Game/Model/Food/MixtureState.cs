using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixtureState : IProductState
{
    public string GetUpgradePrice(int whichShelf)
    {
        return ProductsManager.Instance.GetMixtureUpgradePrice(whichShelf).ToString();
    }

    public string LevelLog(int whichShelf)
    {
        return $"{ProductsManager.Instance.MixtureValues.GetValue(whichShelf)} Level = {PlayerPrefs.GetInt(ProductsManager.Instance.MixtureValues.GetValue(whichShelf).ToString())})";
    }

    public void UpdateLevel(int whichShelf, int currentLevel)
    {
        ProductsManager.Instance.UpdateMixtureLevel(whichShelf, currentLevel);
    }

    public string GetCurrentPrice(int whichShelf)
    {
        return ProductsManager.Instance.GetMixturePrice(whichShelf).ToString();
    }

    public string GetNextPrice(int whichShelf)
    {
        return ProductsManager.Instance.GetMixtureNextPrice(whichShelf).ToString();
    }
}
