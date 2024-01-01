using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionPanel : Overlay
{
    [SerializeField] private TextKeyPair missionIncome;
    [SerializeField] private TextKeyPair missionCustomers;
    [SerializeField] private TextKeyPair happyCustomers;
    [SerializeField] private TextKeyPair visitedCustomers;

    [SerializeField] private TextKeyPair LevelHeader;


    public void SetLevel() 
    {
        LevelHeader.SetDescription(ref GameSystem.Instance.LevelCollections.LevelGroups[GameSystem.Instance.PlayerLevel].level.id);
    }

    public void SetIncome(string income)
    {
        missionIncome.SetDescription(ref income);
    }

    public void SetCustomersTotal(string customersTotal)
    {
        missionCustomers.SetDescription(ref customersTotal);
    }

    public void SetHappyCustomersTotal(string happyCustomersTotal)
    {
        happyCustomers.SetDescription(ref happyCustomersTotal);
    }

    public void SetVisitedCustomersTotal(string customersTotal)
    {
        visitedCustomers.SetDescription(ref customersTotal);
    }
}
