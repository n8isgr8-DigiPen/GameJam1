////////////////////
///Name: Zach Scott
///Date: 11/4/2020 & 11/5/2020
///Desc: A script that causes random items (Chosen from a list of prefabs) to spawn in a random location (with paramiters of choice).
////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [Tooltip("This is what will be spawned.")]
    public GameObject[] StuffToBeSpawned;

    [Space(20)]

    [Tooltip("Time before the next spawn.")]
    public float Cooldown = 1;
    float Timer = 0;

    [Header("X Spawn Range")]
    [Tooltip("The minimum place on the x axis the the object will spawn")]
    public float xMin = -1;
    [Tooltip("The maximum place on the x axis the the object will spawn")]
    public float xMax = 1;

    [Header("Y Spawn Range")]
    [Tooltip("The minimum place on the y axis the the object will spawn")]
    public float yMin = -1;
    [Tooltip("The maximum place on the y axis the the object will spawn")]
    public float yMax = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= Cooldown)
        {
            SpawnObject();
            Timer = 0;
        }
    }

    void SpawnObject()
    {
        Vector2 pos = new Vector2 (Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        GameObject Thingy = StuffToBeSpawned[Random.Range(0, StuffToBeSpawned.Length)];
        Instantiate (Thingy, pos, transform.rotation);
    }
}
