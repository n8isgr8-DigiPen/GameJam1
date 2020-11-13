/*
Name: Nate Stern
Date: 11/9/20
Desc: Bullet script that finds homing targets and moves towards them / no activity if not homing
*/
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //target gameobject
    private GameObject target;
    //whether to run script or not (set in fighting script)
    public bool useHoming;

    //wave spawning object to get enemies
    private GameObject waveSpawning;

    private void Start()
    {
        if(useHoming)
        {
            //set enemy and enemy wave manager
            waveSpawning = GameObject.Find("WaveManager");
            UpdateClosestEnemy();
        }
    }

    private void Update()
    {
        if(useHoming)
        {
            //assign target if current has died or destroyed
            if (target == null)
            {
                UpdateClosestEnemy();
            }
            //look towards enemy if not null
            if(target != null)
            {
                transform.right = target.transform.position - transform.position;
            }
            //mvoe forwards towards enemy
            GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
        }
    }

    /// <summary>
    /// finds closest enemy to the current object and sets to target
    /// </summary>
    private void UpdateClosestEnemy()
    {
        GameObject closestEnemy = null;
        float maxDistance = Mathf.Infinity;
        //for each enemy in all the enemies, find the least far enemy
        foreach (GameObject enemy in waveSpawning.GetComponent<WaveSpawning>().spawnedEntities)
        {
            //test distance
            float distance = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            if (distance < maxDistance)
            {
                //if distance is lower than current lowest enemy change enemy/distance
                closestEnemy = enemy;
                maxDistance = distance;
            }
        }
        //set the final target as the closest enemy
        target = closestEnemy;
    }
}
