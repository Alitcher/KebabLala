using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductHandler : MonoBehaviour
{
    public KebabMixtures ProductType;
    public Drinks DrinkType;
    public Product product;
    public Container mealPlate;
    private bool handed = false;

    public bool onPlate;
    public ProductHandler otherHandler;
    CustomerHandler customer;
    [SerializeField] private PlateHandler plate;

    [SerializeField] private bool isDragging = false; 
    public void SetDragging(bool isOnDrag) 
    {
    isDragging = isOnDrag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "customer")
        {
            isDragging = true; // assuming that when the product hit the customer, the player is holding this product.

            customer = collision.gameObject.GetComponent<CustomerHandler>();
            if (customer.wantsKebab() && !GameSystem.Instance.gameManager.IsEarlyCustomer() && plate!= null && plate.kebabData != null)
            {
                plate.SetButtonAppearance();
                customer.SetKebabHanded();
            }
            handed = true;
        }
        else if (collision.tag == "plate")
        {
            plate = collision.gameObject.GetComponent<PlateHandler>();
            isOnPlate();
        }
        else if (this.tag == "plate" && collision.tag == "customer")
        {
            customer = collision.gameObject.GetComponent<CustomerHandler>();
            plate = this.gameObject.GetComponent<PlateHandler>();
            handed = true;
        }
       DoShakeAnimation();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("ResetHanded", 0.5f);
    }

    private void ResetHanded()
    {
        customer = null;
        handed = false;
    }

    private bool IsCustomerValidForProduct()
    {
        return !(customer == null || (this.tag == "plate" && customer.KebabData == null));
    }

    private bool CheckProductMatchWithCustomer()
    {
        return (this.tag == "plate") ? customer.KebabData.CheckMatch(plate.id, true)
                                     : customer.CheckProductMatch(product.id, ref handed);
    }

    private bool CheckProductMatchTrigger()
    {
        return (this.tag == "plate") ? customer.KebabData.CheckMatch(plate.id, false)
                                     : customer.CheckProductMatch(product.id);
    }

    private void DoShakeAnimation()
    {
        //if customer.KebabData.CheckMatch(plate.id) is true then shake this object in local position x and y
        // Shake the GameObject for 0.5 seconds in the x and y local position with a strength of 1,
        // 10 vibrato (jumps per second), 90 degrees randomness, snapping to the nearest whole number off, 
        // and fade out true so the animation eases out towards the end.
        if (customer != null && CheckProductMatchTrigger())
        {
        }
    }

    public bool isValidToCustomer()
    {
        // Checks if the customer is null or if the product is a plate without kebab data
        if (!IsCustomerValidForProduct())
        {
            return false;
        }

        // Check if the product matches what the customer wants
        bool checkMatch = CheckProductMatchWithCustomer();

        // Handles the logic when the product matches
        if (checkMatch)
        {
            //disable customer plate
           // customer.DisableKebabPlate();
            HandleMatchingProduct();
        }

        return checkMatch;
    }

    private void HandleMatchingProduct()
    {
        if (this.tag != "plate") // For products like ayran and cola
        {
            HandleDrinkProduct();
        }
        else // For kebab plates
        {
            HandleKebabPlate();
        }
    }

    private void HandleDrinkProduct()
    {
        int currentProductLevel = GetCurrentProductLevel();

        GameSystem.Instance.gameManager.EarnMoney(product.sell[currentProductLevel]);
    }

    private int GetCurrentProductLevel()
    {
        switch (product.name)
        {
            case "Cola": return PlayerPrefs.GetInt(ProductList.Cola.ToString());
            case "Ayran": return PlayerPrefs.GetInt(ProductList.Ayran.ToString());
            default: return 0;
        }
    }

    private void HandleKebabPlate()
    {
        plate.SetButtonAppearance();
        customer.SetKebabHanded();
        plate.ClearCollection();
        GameSystem.Instance.gameManager.increaseTime(5);
        GameSystem.Instance.gameManager.EarnMoney(plate.KebabPlatePrice);
    }


    internal bool isOnPlate()
    {
        if (plate == null)
            return false;

        plate.SetActiveCollection(this.name.Replace("Product", ""));
        return true;
    }


}
