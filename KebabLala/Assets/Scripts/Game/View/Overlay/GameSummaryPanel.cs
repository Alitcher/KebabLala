using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSummaryPanel : Overlay
{
    [SerializeField] private TextKeyPair missionIncome;
    [SerializeField] private TextKeyPair missionCustomers;
    [SerializeField] private TextKeyPair Tips;
    [SerializeField] private TextKeyPair happyCustomers;
    [SerializeField] private TextKeyPair upsetCustomers;
    [SerializeField] private TextKeyPair leftCustomers;

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
        happyCustomers.SetDescription(ref happyCustomersTotal);
    }

    public void SetUpsetCustomersTotal(string upsetCustomersTotal)
    {
        upsetCustomers.SetDescription(ref upsetCustomersTotal);
    }

    public void SetVisitedCustomersTotal(string leftoffCustomer)
    {
        leftCustomers.SetDescription(ref leftoffCustomer);
    }
}
