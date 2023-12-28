using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Product", menuName = "KebabLala/Food/Product")]
public class Product : ScriptableObject
{
    public ProductType productType = ProductType.Drink;
    public Sprite avatar;
    public string productName;
    public string id;
    public int shelfIndex;
    public int[] sell;
    public int[] buy;
}

 