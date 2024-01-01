using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{
    [SerializeField] private ProductNode[] ProductNodeCollection;
    [SerializeField] private Button ResetLevelButton;

    void Start()
    {
        SetProductNodeAppearance();
        ResetLevelButton.onClick.AddListener(() => {
            ProductsManager.Instance.ResetMixtureLevel();
            ProductsManager.Instance.ResetDrinkLevel();
            ResetData(); });
    }

    public void SetProductNodeAppearance()
    {
        for (int n = 0; n < ProductNodeCollection.Length; n++)
        {
            ProductNodeCollection[n].InitData();
        }
    }

    public void ResetData() 
    {
        for (int n = 0; n < ProductNodeCollection.Length; n++)
        {
            ProductNodeCollection[n].ResetData();
        }
    }
}
