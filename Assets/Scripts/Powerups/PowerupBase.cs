/*
Name: Nate Stern
Date: 11/6/20
Desc: Base Class all temporary powerups go through
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    //method every powerup requires
    public abstract void Pickup();

    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("Powerup trigger");
        if (!c.tag.Equals("Player")) return;
        Pickup();
        Destroy(gameObject);
    }
        
    
}
