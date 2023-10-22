using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new CustomerType", menuName = "KebabLala/Customers")]
public class Customer : ScriptableObject
{
    public string customerName;
    public string id;
    public Sprite avatar;
    public int[] desiredFood;
    public float waitingTime;
}
