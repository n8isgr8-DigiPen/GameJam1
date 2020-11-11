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
    public Transform bulletSpawnPoint;

    // Update is called once per frame
    void Update() 
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (timer >= shootDelay) 
            {
                //Spawn Bullet
                ShootBullet();
            }
        }
    }

    private void ShootBullet()
    {
        for (int i = 0; i < PlayerManager.BulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, i == 0 ? 0 : Random.Range(-.35f, .35f));
            bullet.GetComponent<Bullet>().useHoming = PlayerManager.UseHomingBullets;
            Destroy(bullet, 2);
        }
        timer = 0;
    }

}
