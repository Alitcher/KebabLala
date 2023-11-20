using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    [SerializeField] private ShelfHandler DrinkShelf;
    [SerializeField] private ShelfHandler VeggieShelf;
    [SerializeField] private ShelfHandler SauceShelf;

    [SerializeField] private ShelfHandler PoleShelf;
    [SerializeField] private ShelfHandler DonerShelf;

    [SerializeField] private ShelfHandler PlateShelf1;
    [SerializeField] private ShelfHandler PlateShelf2;


    public void SetActiveShelves(Shelves whichShelf) 
    {
        switch (whichShelf)
        {
            case Shelves.None:
                break;
            case Shelves.Drink:
                DrinkShelf.gameObject.SetActive(true);
                break;
            case Shelves.Veggie:
                VeggieShelf.gameObject.SetActive(true);
                break;
            case Shelves.Sauce:
                SauceShelf.gameObject.SetActive(true);
                break;
            case Shelves.Pole:
                PoleShelf.gameObject.SetActive(true);
                break;
            case Shelves.Doner:
                DonerShelf.gameObject.SetActive(true);
                break;
            case Shelves.Plate1:
                PlateShelf1.gameObject.SetActive(true);
                break;
            case Shelves.Plate2:
                PlateShelf2.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void EnableAllShelves()
    {
        DrinkShelf.gameObject.SetActive(true);
        VeggieShelf.gameObject.SetActive(true);
        SauceShelf.gameObject.SetActive(true);
        PoleShelf.gameObject.SetActive(true);
        DonerShelf.gameObject.SetActive(true);
        PlateShelf1.gameObject.SetActive(true);
        PlateShelf2.gameObject.SetActive(true);
    }

    public void DisableAllShelves()
    {
        DrinkShelf.gameObject.SetActive(false);
        VeggieShelf.gameObject.SetActive(false);
        SauceShelf.gameObject.SetActive(false);
        PoleShelf.gameObject.SetActive(false);
        DonerShelf.gameObject.SetActive(false);
        PlateShelf1.gameObject.SetActive(false);
        PlateShelf2.gameObject.SetActive(false);
    }

    public void SetActiveProducts(KebabMixtures whichMixture)
    {
        ActivateMixturesOnShelf(VeggieShelf, whichMixture);
        ActivateMixturesOnShelf(SauceShelf, whichMixture);
        ActivateMixturesOnShelf(PoleShelf, whichMixture);
        ActivateMixturesOnShelf(DonerShelf, whichMixture);
    }

    public void DisapleMixtureInShelves() 
    {
        DrinkShelf.DisableAllMixtures();
        VeggieShelf.DisableAllMixtures();
        SauceShelf.DisableAllMixtures();
        PoleShelf.DisableAllMixtures();
        DonerShelf.DisableAllMixtures();
    }

    private void ActivateMixturesOnShelf(ShelfHandler shelf, KebabMixtures whichMixture)
    {
        if (shelf.gameObject.activeSelf)
        {
            shelf.SetActiveMixtures(whichMixture);
        }
    }

    public void SetActiveDrinks(Drinks whichDtink)
    {
        DrinkShelf.SetActiveMixtures(whichDtink);
    }


    public void SetActivePlates(int plate1amount, int plate2amount)
    {
        ActivatePlatesOnShelf(PlateShelf1, plate1amount);
        ActivatePlatesOnShelf(PlateShelf2, plate2amount);
    }

    private void ActivatePlatesOnShelf(ShelfHandler shelf, int amount)
    {
        if (shelf.gameObject.activeSelf && amount > 0)
        {
            shelf.SetActiveMixturesPlate(amount);
        }
    }
}

