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
    //powerup audio source
    private AudioSource powerup;

    //adds powerup audio source and makes powerup move backwards for ship moving forwards effect always.
    private void Start()
    {
        powerup = GameObject.Find("Player").GetComponent<AudioSource>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-25, 0));
    }

    //runs pickup and destroys object on collision
    private void OnTriggerEnter2D(Collider2D c)
    {
        //if not player, return
        if (!c.CompareTag("Player")) return;
        //player powerup sound
        powerup.Play();
        //pickup and destroy object
        Pickup();
        Destroy(gameObject);
    }
        
    
}
