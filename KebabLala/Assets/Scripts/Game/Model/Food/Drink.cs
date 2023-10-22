using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Drink", menuName = "KebabLala/Drink")]
public class Drink : ScriptableObject
{
    public ProductData productType = ProductData.Drink;
    public Sprite avatar;
    public string drinkName;
    public string id;
    public int sell;
    public int buy;
}

 