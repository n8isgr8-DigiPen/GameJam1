//Name: Eric Lighthall
//Date: 11/4/2020
//Desc: Spawns the bullet prefab from the player with a set velocity.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float BulletSpeed;
    private float timer;
    [Tooltip("Time between shots")]
    public float shootDelay = .2f;
    public bool hasHomingBullets = false;
    public Transform bulletSpawnPoint;
    private GameObject waveSpawning;
    
    void Start()
    {
        waveSpawning = GameObject.Find("WaveManager");
    }

    // Update is called once per frame
    void Update() 
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (timer >= shootDelay) 
            {
                //Spawn Bullet
                GameObject Bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
                GameObject closestEnemy = findClosestEnemy();
                if (hasHomingBullets && closestEnemy != null)
                {
                    //Sets the bullets velocity to the vector of the nearest enemy - the bullet spawn point.
                    Bullet.GetComponent<Rigidbody2D>().velocity = (closestEnemy.transform.position - bulletSpawnPoint.transform.position).normalized * BulletSpeed;
                }
                else
                {
                    Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, 0);
                }
                timer = 0;
                Destroy(Bullet, 2);
            }
        }
    }

    //Finds the nearest enemy in the scene
    private GameObject findClosestEnemy()
    {
        GameObject closestEnemy = null;
        float maxDistance = Mathf.Infinity;
        foreach (GameObject enemy in waveSpawning.GetComponent<WaveSpawning>().spawnedEntities)
        {
            float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distance < maxDistance)
            {
                closestEnemy = enemy;
                maxDistance = distance;
            }
        }
        return closestEnemy;
    }
}
