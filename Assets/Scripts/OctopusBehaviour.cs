using UnityEngine;
using System.Collections;
using System;
/*
Name: Evan Anderson
Date: 11/5/2020
Desc: Basic Enemy (Octopus) only moves from left to right and dashes forward and up every once in a while
*/
[RequireComponent(typeof(Rigidbody2D))]
public class OctopusBehaviour : MonoBehaviour
{
    //NOT READY, SAVING FOR LATER
    Rigidbody2D octopusRB;
    public int DebugDashSpeed = 10;
    public float DebugDashFrequency = 10;
    public float DebugDashTime = 3;

    // Use this for initialization
    void Start()
    {
        throw new NotImplementedException();
        octopusRB = GetComponent<Rigidbody2D>();
        StartCoroutine(Dash());
    }

 
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(.5f);
        octopusRB.AddForce(new Vector2(-DebugDashSpeed, DebugDashSpeed));
        yield return new WaitForSeconds(.5f);
        //octopusRB.AddForce(new Vector2(DebugDashSpeed));
        
        StartCoroutine(Dash());
    }

}
