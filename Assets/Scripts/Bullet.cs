using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    public bool useHoming;
    private GameObject waveSpawning;

    private void Start()
    {
        if(useHoming)
        {
            waveSpawning = GameObject.Find("WaveManager");
            UpdateClosestEnemy();
        }
    }

    private void Update()
    {
        if(useHoming)
        {
            if (target == null)
            {
                UpdateClosestEnemy();
            }
            if(target != null)
            {
                transform.right = target.transform.position - transform.position;
            }
            GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
        }
    }

    private void UpdateClosestEnemy()
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
        target = closestEnemy;
    }
}
