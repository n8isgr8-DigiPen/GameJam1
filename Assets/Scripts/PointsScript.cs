using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Name: Evan Anderson
Date: 11/4/2020
Desc: this script adds points whenever the event triggers, whether its on a death of an enemy or something else
*/
public class PointsScript : MonoBehaviour
{

    
    [Tooltip("How many points to add when triggered")]
    public int points = 10;

    public void AddPoints()
    {
        GameManager.Score += points;
    }
}
