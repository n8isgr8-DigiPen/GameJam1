﻿//Name: Eric Lighthall
//Date 11/4/2020
//Desc: Attach on player bullet to damage things with the health script attached.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 10;
    public bool DestroyOnCollide = true;
    public string DestroyOn;
    public GameObject HitPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if(otherHealth != null)
        {
            otherHealth.updateHealth(-damage);
            Instantiate(HitPrefab, transform.position, Quaternion.Euler(transform.up));
        }
        if (DestroyOnCollide)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == DestroyOn && gameObject.tag == "Enemy")
        {
            GameObject.Find("WaveManager").GetComponent<WaveSpawning>().spawnedEntities.Remove(gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == DestroyOn)
        {
            Destroy(gameObject);
        }
    }
}
