using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MixtureNode : ProductNode
{
    [SerializeField] private Product[] products;
    private IProductState currentState;

    public override void InitData() 
    {
        base.InitData();
        currentState = (products[0].productType == ProductType.Drink) ? (IProductState)new DrinkState() : new MixtureState();
        currentState.SetSellPrice(this);
        setSellPrice(0);
        SetActiveStars();

        UpgradeBtn.onClick.AddListener(UpdateNewPrice);
    }

    public void setSellPrice(int currentProductLevel)
    {
        currentLevel = currentProductLevel;


        upgradePriceText.text = currentState.GetUpgradePrice(products[0].shelfIndex);
        currentPriceText.text = (products[0].productType == ProductType.Mixture) ? ProductsManager.Instance.GetMixturePrice(products[0].shelfIndex).ToString()
                                                                                : ProductsManager.Instance.GetDrinkPrice(products[0].shelfIndex).ToString();

        nextPriceText.text = (products[0].productType == ProductType.Mixture) ? ProductsManager.Instance.GetMixtureNextPrice(products[0].shelfIndex).ToString()
                                                                                : ProductsManager.Instance.GetDrinkNextPrice(products[0].shelfIndex).ToString();

    }

    public void UpdateNewPrice() 
    {
        base.UpgradeLevel();

        currentState.UpdateLevel(products[0].shelfIndex, currentLevel);

        upgradePriceText.text = currentState.GetUpgradePrice(products[0].shelfIndex);

        currentPriceText.text = (products[0].productType == ProductType.Mixture) ? ProductsManager.Instance.GetMixturePrice(products[0].shelfIndex).ToString()
                                                                                : ProductsManager.Instance.GetDrinkPrice(products[0].shelfIndex).ToString();

        nextPriceText.text = (products[0].productType == ProductType.Mixture) ? ProductsManager.Instance.GetMixtureNextPrice(products[0].shelfIndex).ToString()
                                                                                : ProductsManager.Instance.GetDrinkNextPrice(products[0].shelfIndex).ToString();
    }

}
