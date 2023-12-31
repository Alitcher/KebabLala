using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new DevAccount", menuName = "KebabLala/User/newAccountDev")]
public class User : ScriptableObject
{
    public string id;
    public string username;
    public string password;
    public int balance;
    public int customerCount;
    public int maxLevel;
    public int playingLevel;
    public int exp;
    public int upsetCount;
    public int happyCount;
}
