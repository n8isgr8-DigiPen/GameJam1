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
    // Update is called once per frame
    void Update() 
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (timer > shootDelay) 
            {
                GameObject Bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
                if (!hasHomingBullets)
                {
                    Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, 0);
                }
                else
                {
                    //implement homing powerup here
                }
                timer = 0;
                Destroy(Bullet, 2);
            }
        }
    }
}
