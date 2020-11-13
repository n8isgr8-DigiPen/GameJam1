using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson (Additions by Nate)
Date: 11/5/2020
Desc: More complex enemy, moves in a sine wave and fires at the player
*/
public class EelBehaviour : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 target;
    Vector2 spawn;
    [Tooltip("What bullet to fire")]
    public GameObject bolt;
    [Tooltip("Distance up and down")]
    public float distance = 2;
    [Tooltip("How fast up and down")]
    public float speed = 10;
    [Tooltip("How Fast the bullets move")]
    public float bulletSpeed = 10;
    [Tooltip("How Often the bullets fire")]
    public float FireRate = 1;

    // Use this for initialization
    void Start()
    {
        //set start position to spawn position for sin wave motion
        startPosition = transform.position;
        //start endless firing for this enemy.
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        // move in the sine wave motion
        transform.position = startPosition + new Vector2(0, Mathf.Sin(speed * Time.time)) * distance;
        //assign target as player position
        target = GameObject.Find("Player").transform.position;
        //look at player
        transform.right = target - (Vector2)transform.position;
    }

    IEnumerator Fire()
    {
        //run forever until destroyed
        while (true)
        {
            //create a bolt looking towards the player
            GameObject g = Instantiate(bolt, transform.Find("Spawn").position, transform.rotation);
            //move the bolt in a line towards the player
            g.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
            //destroy the bolt after 10 seconds
            Destroy(g, 10);
            //wait # of seconds and spawn another
            yield return new WaitForSeconds(FireRate);
        }
    }
}