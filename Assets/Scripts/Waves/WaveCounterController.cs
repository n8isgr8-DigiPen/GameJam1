using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
Name: Evan Anderson
Date: 11/8/2020
Desc: Controls the ui for tracking 
*/
public class WaveCounterController : MonoBehaviour
{
    Text Waves;
    Text Sharks;
    Text Pufferfish;
    Text Octopi;
    Text Mantas;
    Text Eels;
    GameObject wm;
    int wave;
    Creatures[] waves;
    // Start is called before the first frame update
    void Start()
    {
        Waves = GameObject.Find("Waves").GetComponent<Text>();
        Sharks = GameObject.Find("Sharks").GetComponent<Text>();
        Pufferfish = GameObject.Find("Pufferfish").GetComponent<Text>();
        Octopi = GameObject.Find("Octopus").GetComponent<Text>();
        Mantas = GameObject.Find("Manta").GetComponent<Text>();
        Eels = GameObject.Find("Eel").GetComponent<Text>();
        
        wm = GameObject.Find("WaveManager");
        waves = wm.GetComponent<WaveManager>().waves;

        Sharks.text = "";
        Pufferfish.text = "";
        Octopi.text = "";
        Mantas.text = "";
        Eels.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        
        wave = wm.GetComponent<WaveSpawning>().wave;
        Waves.text = "Wave: " + (wave+1);
        if(waves[wave].creatures[0] != 0)
        {
            Sharks.text = "Sharks: " + waves[wave].creatures[0];
        }
        else
        {
            Sharks.text = "";
        }
        if (waves[wave].creatures[1] != 0)
        {
            Pufferfish.text = "Pufferfish: " + waves[wave].creatures[1];
        }
        else
        {
            Pufferfish.text = "";
        }
        if (waves[wave].creatures[2] != 0)
        {
            Octopi.text = "Octopi: " + waves[wave].creatures[2];
        }
        else
        {
            Octopi.text = "";
        }
        if (waves[wave].creatures[3] != 0)
        {
            Mantas.text = "Mantas: " + waves[wave].creatures[3];
        }
        else
        {
            Mantas.text = "";
        }
        if (waves[wave].creatures[4] != 0)
        {
            Eels.text = "Eels: " + waves[wave].creatures[4];
        }
        else
        {
            Eels.text = "";
        }
    }
}
