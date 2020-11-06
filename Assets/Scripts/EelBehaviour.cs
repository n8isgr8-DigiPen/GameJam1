﻿using UnityEngine;
using System.Collections;

public class EelBehaviour : MonoBehaviour
{
    Vector2 startPosition;
    Vector2 target;
    public Vector2 spawn;
    public GameObject bolt;
    public float distance = 2;
    public float speed = 10;
    public float bulletSpeed = 10;
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
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = mouseScreenPosition;
        Vector3 lookAt = target;
        spawn = transform.position;
        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
    IEnumerator Fire()
    {
        while (true)
        {
            SpawnFinder();
            GameObject g = Instantiate(bolt, spawn, transform.rotation);
            g.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletSpeed);
            Destroy(g, 10);
            yield return new WaitForSeconds(FireRate);
        }
    }
    void SpawnFinder()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).tag == "EelBoltSpawn")
            {
                spawn = transform.GetChild(i).position;
            }
        }
    }
}