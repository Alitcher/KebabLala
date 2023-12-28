using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Product", menuName = "KebabLala/Food/Container")]
public class Container : ScriptableObject
{
    public ProductType productType = ProductType.Plate;
    public string id;
    public Sprite avatar;
    public string foodName;
    public bool[] isMixtureActive;
    public int[] plateActiveCount;

}

 