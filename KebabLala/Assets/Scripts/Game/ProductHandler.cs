using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductHandler : MonoBehaviour
{
    public Drink product;
    public Food mealPlate;
    private bool handed = false;
    private bool isCorrectProduct = false;

    public bool onPlate;

    CustomerHandler customer;
    [SerializeField] private PlateHandler plate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "customer")
        {
            customer = collision.gameObject.GetComponent<CustomerHandler>();
            Debug.Log($"Deliver {this.name} to {customer.name}");
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
            Debug.Log($"Deliver Kebab to {customer.name}");

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

        bool checkMatch = (this.tag == "plate") ? customer.CheckProductMatch(ref plate.FoodCollection) 
            : customer.CheckProductMatch(product.id, ref handed);

        if (checkMatch && handed && (this.tag != "plate")) 
        {
            GameManager.Instance.EarnMoney(product.sell);
        }
        else if(checkMatch && handed && (this.tag == "plate"))
        {
            plate.ClearCollection();
            GameManager.Instance.increaseTime(5);
            GameManager.Instance.EarnMoney(150);

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
