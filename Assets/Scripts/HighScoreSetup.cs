using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
Date: 11/4/2020
Desc: Handles highscore changes and creates player pref if it doesnt exist
*/
public class HighScoreSetup : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", GameManager.Score);
            PlayerPrefs.Save();
        }
    }
    private void Start()
    {
        //If this is the players first time playing, it will create a new player pref of the high score
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", 0);
        }
    }
}
