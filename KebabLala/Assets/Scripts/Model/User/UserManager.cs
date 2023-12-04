using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserManager : MonoBehaviour
{

    public User UserData;

    public void ClearAllPlayerPrefs()
    {
        foreach (string name in Enum.GetValues(typeof(UserDataSavedList)))
        {
            PlayerPrefs.DeleteKey(name);
        }
    }

    public void ResetMixtureLevel()
    {
        Array mixtureValues = Enum.GetValues(typeof(MixtureSavedList));
        int length = mixtureValues.Length;

        for (int i = 1; i < length; i++)
        {
            string name = mixtureValues.GetValue(i).ToString();
            PlayerPrefs.SetInt(name, 0);
        }
    }
}
