using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductHandler : MonoBehaviour
{
    public KebabMixtures ProductType;
    public Drinks DrinkType;
    public Drink product;
    public Food mealPlate;
    private bool handed = false;
    private bool isCorrectProduct = false;

    public bool onPlate;
    public ProductHandler otherHandler;
    CustomerHandler customer;
    [SerializeField] private PlateHandler plate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "customer")
        {
            customer = collision.gameObject.GetComponent<CustomerHandler>();
            if (customer.wantsKebab() && !GameSystem.Instance.gameManager.IsEarlyCustomer() && plate!= null && plate.kebabData != null)
            {
                Debug.Log("Match " + plate.kebabData.CheckMatch(customer.KebabData.Mixtures));
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
            //Debug.Log($"Deliver Kebab to {customer.name}");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Invoke("ResetHanded", 0.5f);
    }

    private void ResetHanded()
    {
        handed = false;
    }

    public bool isValidToCustomer()
    {
        if (customer == null)
            return false;

        bool checkMatch = (this.tag == "plate") ? customer.KebabData.CheckMatch(customer.KebabData.Mixtures)
            : customer.CheckProductMatch(product.id, ref handed);

        if (checkMatch && handed && (this.tag != "plate"))
        {
            GameSystem.Instance.gameManager.EarnMoney(product.sell);
        }
        else if (checkMatch /*&& handed */&& (this.tag == "plate"))
        {
            plate.SetButtonAppearance();
            customer.SetKebabHanded();
            plate.ClearCollection();
            GameSystem.Instance.gameManager.increaseTime(5);
            GameSystem.Instance.gameManager.EarnMoney(150);

        }

        return checkMatch;
    }

    internal bool isOnPlate()
    {
        if (plate == null)
            return false;

        plate.SetActiveCollection(this.name.Replace("Product", ""));
        return true;
    }


}
