using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSummaryPanel : Overlay
{
    [SerializeField] private TextKeyPair missionIncome;
    [SerializeField] private TextKeyPair missionCustomers;
    [SerializeField] private TextKeyPair Tips;
    [SerializeField] private TextKeyPair happyCustomers;
    [SerializeField] private TextKeyPair upsetCustomers;
    [SerializeField] private TextKeyPair leftCustomers;
    [SerializeField] private TextMeshProUGUI LevelStatusText;


    public void SetMissionStatus(bool isCompleted) 
    {
        LevelStatusText.text = isCompleted ? "Completed!" : "Fail :(";
    }

    public void SetIncome(string income)
    {
        missionIncome.SetDescription(ref income);
    }

    public void SetCustomersTotal(string customersTotal)
    {
        missionCustomers.SetDescription(ref customersTotal);
    }

    public void SetTipsTotal(string tips)
    {
        Tips.SetDescription(ref tips);
    }

    public void SetHappyCustomersTotal(string happyCustomersTotal)
    {
        SetTextKeyPairVisibility(ref happyCustomers, happyCustomersTotal);
    }

    public void SetUpsetCustomersTotal(string upsetCustomersTotal)
    {
        SetTextKeyPairVisibility(ref upsetCustomers, upsetCustomersTotal);
    }

    public void SetVisitedCustomersTotal(string leftoffCustomer)
    {
        leftCustomers.SetDescription(ref leftoffCustomer);
    }

    private void SetTextKeyPairVisibility(ref TextKeyPair customerTextKeyPair, string customersTotal)
    {
        bool isActive = !string.IsNullOrEmpty(customersTotal);
        customerTextKeyPair.gameObject.SetActive(isActive);

        if (isActive)
        {
            customerTextKeyPair.SetDescription(ref customersTotal);
        }
    }
}
