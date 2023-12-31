using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductNode : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI currentPriceText, nextPriceText, arrowText;
    [SerializeField] protected Text upgradePriceText;
    [SerializeField] protected Image currencyIcon;

    [SerializeField] protected Color32[] ActiveColors;
    [SerializeField] protected Image[] MixturesImgs;


    [SerializeField] protected Image[] Stars;
    [SerializeField] protected Color32[] ActiveColorStars;

    [SerializeField] protected int Cost;
    [SerializeField] protected int CurrectPrice;
    [SerializeField] protected int NextPrice;

    [SerializeField] protected Button UpgradeBtn;

    public int currentLevel;
    protected string ProductName;


    public virtual void InitData()
    {
        print("init");
    }

    public virtual void SetActiveStars()
    {
        for (int s = 0; s < Stars.Length; s++)
        {
            Stars[s].color = ActiveColorStars[(s <= currentLevel) ? 1 : 0];
        }
    }

    public void UpgradeLevel() 
    {
        currentLevel = (currentLevel < 2) ? currentLevel + 1 : 2;
    }

    public virtual void ResetData()
    {
        currentLevel = 0;
        SetActiveStars();
    }
}
