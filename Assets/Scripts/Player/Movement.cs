﻿/*
Name: Nate Stern
Date: 11/4/20
Desc: Moves the player using wasd or arrow keys. based on velocity with a max speed cap.
*/

using UnityEngine;

//adds a rigidbody 2d by default
[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    //stored rb2d on player object
    Rigidbody2D rb;

    private void Start()
    {
        //get rb2d from gameobject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //gets a vector2 from wasd or arrow keys multiplied by the current player speed
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * PlayerManager.PlayerSpeed * Time.deltaTime, Input.GetAxis("Vertical") * PlayerManager.PlayerSpeed * Time.deltaTime);
        
        //adds movement vector to the current velocity.
        rb.velocity = rb.velocity + movement;

        //caps the movement speed between -8/8 on x and -5/5 on y
        rb.velocity = new Vector2(
            Mathf.Max(-8, Mathf.Min(8, rb.velocity.x)),
            Mathf.Max(-5, Mathf.Min(5, rb.velocity.y)));
    
    }
}
