using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixtureState : IProductState
{
    public void SetSellPrice(MixtureNode mixtureNode)
    {
        // Implementation for Mixture
    }

    public void UpdateNewPrice(MixtureNode mixtureNode)
    {
        // Implementation for Mixture
    }

    public string GetUpgradePrice(int whichShelf)
    {
        return ProductsManager.Instance.GetMixtureUpgradePrice(whichShelf).ToString();
    }

    public void UpdateLevel(int whichShelf, int currentLevel) 
    {
        ProductsManager.Instance.UpdateMixtureLevel(whichShelf, currentLevel);
    }
}
