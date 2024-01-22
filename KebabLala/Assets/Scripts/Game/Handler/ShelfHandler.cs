using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfHandler : MonoBehaviour
{
    [SerializeField] private ProductHandler[] mixtureCollection; //shelf that contains ingredients for the plate
    [SerializeField] private PlateHandler[] plateCollection; // shelf that contains a set of plates

    public void SetActiveMixtures(KebabMixtures whichMixture)
    {
        for (int i = 0; i < mixtureCollection.Length; i++)
        {
                mixtureCollection[i].transform.parent.gameObject.SetActive(true);
        }
    }

    public void SetActiveMixtures(Drinks whichDrink)
    {
        for (int i = 0; i < mixtureCollection.Length; i++)
        {
            if (mixtureCollection[i].DrinkType == whichDrink)
            {
                mixtureCollection[i].transform.parent.gameObject.SetActive(true);
            }
        }
    }

    public void DisableAllMixtures()
    {
        for (int i = 0; i < mixtureCollection.Length; i++)
        {
            mixtureCollection[i].transform.parent.gameObject.SetActive(false);
        }
    }

    public void EnableAllMixtures()
    {
        for (int i = 0; i < mixtureCollection.Length; i++)
        {
            mixtureCollection[i].transform.parent.gameObject.SetActive(true);
        }
    }

    public void SetActiveMixturesPlate(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            plateCollection[i].gameObject.SetActive(true);
            plateCollection[i].ClearCollection();
        }
    }
}
