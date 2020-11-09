using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Name: Evan Anderson
Date: 11/8/2020
Desc: handles when the background should animate
*/
public class BackgroundAnimation : MonoBehaviour
{
    int wave;
    // Update is called once per frame
    void Update()
    {
        wave = GameObject.Find("WaveManager").GetComponent<WaveSpawning>().wave;
        GetComponent<Animator>().SetInteger("wave", wave);
    }
}
