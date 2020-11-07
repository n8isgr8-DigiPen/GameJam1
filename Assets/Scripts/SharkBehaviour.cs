using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
Date: 11/5/2020
Desc: Basic Enemy (Shark) only moves from left to right
*/
[RequireComponent(typeof(Rigidbody2D))]
public class SharkBehaviour : MonoBehaviour
{

    Rigidbody2D sharkRB;
    [Tooltip("The movement speed")]
    public float Speed;
    // Use this for initialization
    void Start()
    {
        sharkRB = GetComponent<Rigidbody2D>();
        sharkRB.AddForce(new Vector2(-Speed, 0));
    }
}
