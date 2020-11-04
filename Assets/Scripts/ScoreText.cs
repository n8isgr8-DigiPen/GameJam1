using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
/*
Name: Evan Anderson
Date: 11/4/2020
Desc: Changes score text when the score changes
*/
public class ScoreText : MonoBehaviour
{
    Text myText;
    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        OnScoreUpdate();
        GameManager.OnScoreChange.AddListener(OnScoreUpdate);
    }

    private void OnScoreUpdate()
    {
        myText.text = "Score: " + GameManager.Score.ToString();
    }
    private void OnDestroy()
    {
        GameManager.OnScoreChange.RemoveListener(OnScoreUpdate);
    }

}
