using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerNode : ProductNode
{
    [SerializeField] private Container Plate;

    public override void InitData()
    {
        //base.InitData();
        setSellPrice(0);
    }
    private void setSellPrice(int currentLevel)
    {
        upgradePriceText.text = Plate.plateActiveCount[currentLevel].ToString(); // current level?
    }
}
