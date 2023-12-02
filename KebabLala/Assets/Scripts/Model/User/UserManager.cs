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
}
