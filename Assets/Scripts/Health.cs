//Name: Eric Lighthall
//Date: 11/5/2020
//Desc: Updates and objects health when called and destroys if no health is left.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    public UnityEvent onDeath = new UnityEvent();
    private GameObject waveSpawner;

    private void Start()
    {
        waveSpawner = GameObject.Find("WaveManager");
        if (tag != "Player") return;
        PlayerManager.PlayerHealth = this;
    }

    public int HEALTH = 50;
    public void updateHealth(int healthChange) 
    {
        HEALTH += healthChange;
        //If enemy dies, remove from list and destroy object.
        if(HEALTH <= 0 && gameObject.tag == "Enemy")
        {
            onDeath.Invoke();
            waveSpawner.GetComponent<WaveSpawning>().spawnedEntities.Remove(gameObject);
            Destroy(gameObject);
        }
        //Else, destroy object on death.
        else if(HEALTH <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
