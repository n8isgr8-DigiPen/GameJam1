using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
Date: 11/8/2020
Desc: Removes a needed kill from the wave counter
*/
public class KillCounter : MonoBehaviour
{
    public int id = 0;
    WaveManager wm;
    int wave;
    private void Update()
    {
        wm = GameObject.Find("WaveManager").GetComponent<WaveManager>();
        wave = GameObject.Find("WaveManager").GetComponent<WaveSpawning>().wave;
    }
    public void RemoveMe()
    {
        if (wm.waves[wave].creatures[id] > 0 && wave != 4)
        {
            wm.waves[wave].creatures[id] -= 1;
        }       
    }
}
