using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ProductCollectionTable-x", menuName = "KebabLala/Food/CollectionTable")]
public class ProductStatCollectionTable : ScriptableObject
{
    public Product[] DrinksList;
    public Product[] MixturesList;
    public Container Plate;
}
