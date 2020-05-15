using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PlayerHealth
{
    public int healthAmount = 20;
    private bool pickup = false;


    void Update()
    {
        if (pickup == true)
            currentHealth += healthAmount;               
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickup = true;
            Destroy(collision.gameObject);

        }
        
    }
}
