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

    //runs pickup and destroys object on collision
    private void OnTriggerEnter2D(Collider2D c)
    {
        //if not player, return
        if (!c.tag.Equals("Player")) return;
        //pickup and destroy object
        Pickup();
        Destroy(gameObject);
    }
        
    
}
