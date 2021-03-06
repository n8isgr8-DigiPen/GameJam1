﻿using UnityEngine;
using System.Collections;
using System;
/*
Name: Evan Anderson
Date: 11/5/2020
Desc: More complex enemy, moves towards player and puffs up when it gets close, making it a bigger target but also easier to get hit by
*/
[RequireComponent(typeof(Rigidbody2D))]
public class PufferFishBehaviour : MonoBehaviour
{
    
    Rigidbody2D pufferfishRB;
    [Tooltip("Movement Speed")]
    public float speed;
    Vector3 target;
    [Tooltip("How Far away will it expand?")]
    public float ExplodeDistance;
    bool exploded = false;
    // Use this for initialization
    void Start()
    {
        
        
        pufferfishRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("Player").transform.position; will impliment when we have player;
        
        
        target = GameObject.Find("Player").transform.position;
        Vector3 perpendicular = Vector3.Cross(target-transform.position,Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        pufferfishRB.velocity = -transform.right * speed;
        if (Vector2.Distance(transform.position, target) <= ExplodeDistance)
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (!exploded)
        {
            transform.localScale *= ExplodeDistance*2;
            exploded = true;
        }
        
    }
}
