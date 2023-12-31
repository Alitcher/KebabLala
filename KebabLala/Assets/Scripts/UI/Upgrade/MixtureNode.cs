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
        currentLevel = PlayerPrefs.GetInt(products[0].name);//= currentProductLevel;

        base.InitData();
        base.ProductName = products[0].productName;
        currentState = (products[0].productType == ProductType.Drink) ? (IProductState)new DrinkState() : new MixtureState();
        SetSellPrice();
        SetActiveStars();

        UpgradeBtn.onClick.AddListener(BuyProduct);
    }

    public override void ResetData()
    {
        base.ResetData();
        print($"Now: {currentState.LevelLog(products[0].shelfIndex)}");
        nextPriceText.gameObject.SetActive(true);
        arrowText.gameObject.SetActive(true);
        UpgradeBtn.interactable = true;
        upgradePriceText.text = currentState.GetUpgradePrice(products[0].shelfIndex);
        nextPriceText.text = currentState.GetNextPrice(products[0].shelfIndex);
        currentPriceText.text = currentState.GetCurrentPrice(products[0].shelfIndex);
    }

    public void SetSellPrice()
    {

        if (currentState.GetNextPrice(products[0].shelfIndex) == "0")
        {
            upgradePriceText.text = "MAX";
            nextPriceText.gameObject.SetActive(false);
            arrowText.gameObject.SetActive(false);
            UpgradeBtn.interactable = false;
        }
        else
        {
            nextPriceText.gameObject.SetActive(true);
            arrowText.gameObject.SetActive(true);
            UpgradeBtn.interactable = true;
            upgradePriceText.text = currentState.GetUpgradePrice(products[0].shelfIndex);
            nextPriceText.text = currentState.GetNextPrice(products[0].shelfIndex);

        }

        currentPriceText.text = currentState.GetCurrentPrice(products[0].shelfIndex);
    }

    public void BuyProduct()
    {
        print($"Before: {currentState.LevelLog(products[0].shelfIndex)}");

        if (products.Length > 1)
        {
            for (int i = 0; i < products.Length; i++)
            {


            }
        }
        else
        {

        }
        UserManager.Instance.UpdateBalance(-products[0].buy[currentLevel]);
        UserManager.Instance.OnUpdateUserStat.Invoke();
        base.UpgradeLevel();
        currentState.UpdateLevel(products[0].shelfIndex, currentLevel);
        SetSellPrice();
        SetActiveStars();
        print($"Now: {currentState.LevelLog(products[0].shelfIndex)}");

    }

    private void CheckProductIndex()
    {
        if (products.Length > 1)
        {
            for (int i = 0; i < products.Length; i++)
            {


            }
        }
    }
}
