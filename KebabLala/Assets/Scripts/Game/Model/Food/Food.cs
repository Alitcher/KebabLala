using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Food", menuName = "KebabLala/Food")]
public class Food : ScriptableObject
{
    public ProductData productType = ProductData.Mixture;
    public string id;
    public int price;
    public Sprite avatar;
    public string foodName;
    public bool[] isMixtureActive;
}

 