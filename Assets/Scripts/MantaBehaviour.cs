using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
Date: 11/5/2020
Desc: Basically a fast shark with some sine movement
*/
public class MantaBehaviour : MonoBehaviour
{
    
    Rigidbody2D MantaRB;
    [Tooltip("The movement speed")]
    public float Speed;
    Vector3 startPosition;
    // Use this for initialization
    void Start()
    {
        
        startPosition = transform.position;
    }

    public float sinSpeed;
    public float distance;
    private void Update()
    {
        startPosition += -transform.right * Time.deltaTime * Speed;
        transform.position = startPosition + transform.up * Mathf.Sin(sinSpeed * Time.time) * distance;
    }
}
