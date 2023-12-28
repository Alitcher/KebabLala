using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopPanelSelection : MonoBehaviour
{

    [SerializeField] private Text customerText, balanceText;

    // Start is called before the first frame update
    void Start()
    {
        UserManager.Instance.OnUpdateUserStat += UpdateUserStat;
        UpdateUserStat();
    }

    private void UpdateUserStat()
    {
        customerText.text = PlayerPrefs.GetInt(UserDataSavedList.CustomerCount.ToString()).ToString();
        balanceText.text = PlayerPrefs.GetInt(UserDataSavedList.MoneyBalance.ToString()).ToString();
    }
}
