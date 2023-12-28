using Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : AliciaGenericSingleton<UserManager>
{
    public User UserData;

    public Action OnUpdateUserStat;
    public int customerCount;// { get; private set; }
    public int balance;// { get; private set; }
    public int upsetCount;// { get; private set; }
    public int happyCount;// { get; private set; }
    public int playingLevel;// { get; private set; }

    public override void Awake()
    {
        base.Awake();
        UpdatePlayingLevel();
        UpdateBalance(150);
        UpdateCustomerCount(0);
        updateEmojis(0, 0);
    }

    public void UpdatePlayingLevel()
    {
        playingLevel++;
        UserData.playingLevel = playingLevel;
        PlayerPrefs.SetInt(UserDataSavedList.PlayingLevel.ToString(), this.playingLevel);
    }

    public void UpdateBalance(int _balance)
    {
        this.balance += _balance;
        UserData.balance = this.balance;
        PlayerPrefs.SetInt(UserDataSavedList.MoneyBalance.ToString(), this.balance);
    }

    public void UpdateCustomerCount(int customers)
    {
        this.customerCount =+ customers;
        UserData.customerCount = this.customerCount;
        PlayerPrefs.SetInt(UserDataSavedList.CustomerCount.ToString(), this.customerCount);
    }

    public void updateEmojis(int _happyCount, int _upsetCount)
    {
        upsetCount = +_upsetCount;
        happyCount = +_happyCount;
        UserData.upsetCount = this.upsetCount;
        UserData.happyCount = this.happyCount;
        PlayerPrefs.SetInt(UserDataSavedList.UpsetReactCount.ToString(), this.upsetCount);
        PlayerPrefs.SetInt(UserDataSavedList.HappyReactCount.ToString(), this.happyCount);
    }

    public void ClearAllPlayerPrefs()
    {
        customerCount = 0;
        balance = 0;
        upsetCount = 0;
        happyCount = 0;
        playingLevel = 0;
        UserData.customerCount = 0;
        UserData.balance = 0;
        UserData.upsetCount = 0;
        UserData.happyCount = 0;
        UserData.playingLevel = 0;
        foreach (string name in Enum.GetValues(typeof(UserDataSavedList)))
        {
            PlayerPrefs.DeleteKey(name);
        }
    }


}
