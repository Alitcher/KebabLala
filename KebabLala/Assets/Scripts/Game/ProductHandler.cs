using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductHandler : MonoBehaviour
{
    public Drink product;
    public Food mealPlate;
    private bool handed = false;
    private bool isCorrectProduct = false;

    public bool isMeal;
    CustomerHandler customer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "customer")
        {
             customer = collision.gameObject.GetComponent<CustomerHandler>();
            Debug.Log($"Deliver {this.name} to {customer.name}");
            handed = true;

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        handed = false;
    }

    public bool isValidToCustomer()
    {
        return customer.CheckProductMatch(product.id) && handed ;
    }

    public void OnDragEnd()
    {
        if (isValidToCustomer())
        {
            GameManager.Instance.EarnMoney(product.sell);

        }
    }
}
