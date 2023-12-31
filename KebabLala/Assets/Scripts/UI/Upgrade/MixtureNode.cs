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
        SetSellPrice(0);
        SetActiveStars();

        UpgradeBtn.onClick.AddListener(UpdateNewPrice);
    }

    public void SetSellPrice(int currentProductLevel)
    {
        currentLevel = currentProductLevel;

        if (currentState.GetNextPrice(products[0].shelfIndex) == "0")
        {
            upgradePriceText.text = "MAX";
            nextPriceText.gameObject.SetActive(false);
            arrowText.gameObject.SetActive(false);
            UpgradeBtn.interactable = false;
        }
        else
        {
            upgradePriceText.text = currentState.GetUpgradePrice(products[0].shelfIndex);
            nextPriceText.text = currentState.GetNextPrice(products[0].shelfIndex);

        }

        currentPriceText.text = currentState.GetCurrentPrice(products[0].shelfIndex);
    }

    public void UpdateNewPrice()
    {
        UserManager.Instance.UpdateBalance(-products[0].buy[currentLevel]);
        UserManager.Instance.OnUpdateUserStat.Invoke();
        base.UpgradeLevel();
        currentState.UpdateLevel(products[0].shelfIndex, currentLevel);
        SetSellPrice(currentLevel);
        SetActiveStars();
    }

}
