//Name: Eric Lighthall (Additions by Nate)
//Date: 11/4/2020
//Desc: Spawns the bullet prefab from the player with either set velocity or as a homing bullet.
using UnityEngine;

public class Fighting : MonoBehaviour
{
    //bullet prefab to launch
    public GameObject bulletPrefab;
    //set bullet speed
    public float BulletSpeed;

    //time and delay between shots
    private float timer;
    [Tooltip("Time between shots")]
    public float shootDelay = .2f;

    //spawnpoint to spawn bullet from
    public Transform bulletSpawnPoint;

    // Update is called once per frame
    void Update() 
    {
        //Add time to timer
        timer += Time.deltaTime;
        //If shoot pressed
        if (Input.GetKey(KeyCode.Space)) 
        {
            //And time has passed the shooting delay
            if (timer >= shootDelay) 
            {
                //Spawn Bullet
                ShootBullet();
            }
        }
    }

    //for each bullet, spawn one, then for each other spawn one going in a slight different direction randomly.
    //if homing: launch that many homing bullets
    private void ShootBullet()
    {
        //for each bullet shooting at the moment
        for (int i = 0; i < PlayerManager.BulletCount; i++)
        {
            //make the bullet
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            //give the bullet a x velocity of bulletspeed
            //give the bullet a y velocity (if first bullet: 0) (if other bullet: random between -.5 and .5 y velocity)
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, i == 0 ? 0 : Random.Range(-.5f, .5f));
            //sets the bullet to homing mode if homing is active at the moment
            bullet.GetComponent<Bullet>().useHoming = PlayerManager.UseHomingBullets;
            //destroy bullet after 2 seconds of fire time
            Destroy(bullet, 2);
        }
        //reset timer for more shooting delay
        timer = 0;
    }

}
