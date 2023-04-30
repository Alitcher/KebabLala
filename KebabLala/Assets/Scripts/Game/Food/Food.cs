using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Food", menuName = "KebabLala/Food")]
public class Food : ScriptableObject
{
    public ProductData productType = ProductData.Meal;
    public Sprite avatar;
    public string foodName;
    public bool hasMeat;
    public bool hasVeggie;
    public bool hasTortilla;
    public string id;
    public int price;
}

 