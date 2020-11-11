using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Name: Evan Anderson
Date: 11/8/2020
Desc: handles spawning of enemies
*/
public class WaveSpawning : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject Shark;
    public GameObject PufferFish;
    public GameObject Octopus;
    public GameObject Manta;
    public GameObject Eel;
    [Header("Positions")]
    public float xPos;
    public float yPos;
    public float yRange;

    string whatToSpawn;
    Vector2 whereToSpawn;

    WaveManager wm;
    [Header("Misc.")]
    public float spawnSpeed = 5;

    public int wave = 0;

    //List of all GameObjects in scene.
    public List<GameObject> spawnedEntities = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        wm = GetComponent<WaveManager>();
        StartCoroutine(Spawning(wave));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wm.waves[wave].creatures.Length);
        waveEnd();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(new Vector3(xPos, yPos), new Vector3(.5f, yRange));
    }
    string CreatureFinder(int id)
    {
        switch (id)
        {
            case 0:
                return "Shark";
            case 1:
                return "PufferFish";
            case 2:
                return "Octopus";
            case 3:
                return "Manta";
            case 4:
                return "Eel";
        }
        return "Incorrect";
    }
    bool waveEnd()
    {
        for (int c = 0; c < wm.waves[wave].creatures.Length; c++)
        {
            if (wm.waves[wave].creatures[c] != 0)
            {
                return false;
            }
            else
            {
                continue;
            }
        }

        if(wave < 4)
        {
            wave += 1;
        }
        Debug.Log(wave);
        StopCoroutine(Spawning(wave));
        StartCoroutine(Spawning(wave));
        return true;
    }
    IEnumerator Spawning(int wave)
    {
        while (true)
        {
            whatToSpawn = CreatureFinder(Random.Range(0, wm.waves[wave].creatures.Length));
            whereToSpawn = new Vector2(xPos, Random.Range(-yRange / 2, yRange / 2));
            switch (whatToSpawn)
            {
                case "Shark":
                    if (wm.waves[wave].creatures[0] > 0)
                    {
                        GameObject newShark = Instantiate(Shark, whereToSpawn, Quaternion.identity);

                    spawnedEntities.Add(newShark);
                    }
                    else
                    {
                        whatToSpawn = CreatureFinder(Random.Range(0, wm.waves[wave].creatures.Length));
                    }
                    break;
                case "PufferFish":
                    if (wm.waves[wave].creatures[1] > 0)
                    {
                        GameObject newPuffer = Instantiate(PufferFish, whereToSpawn, Quaternion.identity);

                    spawnedEntities.Add(newPuffer);
                    }
                    else
                    {
                        whatToSpawn = CreatureFinder(Random.Range(0, wm.waves[wave].creatures.Length));
                    }
                    break;
                case "Octopus":
                    if (wm.waves[wave].creatures[2] > 0)
                    {
                        GameObject newOctopus = Instantiate(Octopus, whereToSpawn, Quaternion.identity);

                    spawnedEntities.Add(newOctopus);
                    }
                    else
                    {
                        whatToSpawn = CreatureFinder(Random.Range(0, wm.waves[wave].creatures.Length));
                    }
                    break;
                case "Manta":
                    if (wm.waves[wave].creatures[3] > 0)
                    {
                        GameObject newManta = Instantiate(Manta, whereToSpawn, Quaternion.identity);

                    spawnedEntities.Add(newManta);
                    }
                    else
                    {
                        whatToSpawn = CreatureFinder(Random.Range(0, wm.waves[wave].creatures.Length));
                    }
                    break;
                case "Eel":
                    if (wm.waves[wave].creatures[4] > 0)
                    {
                        GameObject newEel = Instantiate(Eel, whereToSpawn, Quaternion.identity);

                    spawnedEntities.Add(newEel);
                    }
                    else
                    {
                        whatToSpawn = CreatureFinder(Random.Range(0, wm.waves[wave].creatures.Length));
                    }
                    
                    break;
            }
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    
}
