using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private ProductNode[] ProductNodeCollection;


    void Start() 
    {
        SetProductNodeAppearance();
    }

    public void SetProductNodeAppearance() 
    {
        for (int n = 0; n < ProductNodeCollection.Length; n++)
        {
            ProductNodeCollection[n].InitData();
        }
    }
}
