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
    private void Start()
    {
        if (tag != "Player") return;
        PlayerManager.PlayerHealth = this;
    }

    public int HEALTH = 50;
    public void updateHealth(int healthChange) 
    {
        HEALTH += healthChange;
        if(HEALTH <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
