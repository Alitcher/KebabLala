using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductHandler : MonoBehaviour
{
    public Drink product;
    private bool handed = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "customer")
        {
            CustomerHandler customer = collision.gameObject.GetComponent<CustomerHandler>();
            Debug.Log($"Deliver {this.name} to {customer.name}");
            handed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        handed = false;
    }

    public bool isHandedToCustomer()
    {
        return handed;
    }
}
