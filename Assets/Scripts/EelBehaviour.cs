using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
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
        startPosition = transform.position;
        //target = GameObject.Find("Player").transform.position;

        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + new Vector2(0, Mathf.Sin(speed * Time.time)) * distance;
        target = GameObject.Find("Player").transform.position;
        transform.right = target - (Vector2)transform.position;
    }

    IEnumerator Fire()
    {
        while (true)
        {
            GameObject g = Instantiate(bolt, transform.Find("Spawn").position, transform.rotation);
            g.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
            Destroy(g, 10);
            yield return new WaitForSeconds(FireRate);
        }
    }
}