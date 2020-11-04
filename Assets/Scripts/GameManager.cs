using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*
Name: Evan Anderson
Date: 11/4/2020
Desc: Manages many things (At the moment only score)
*/
public class GameManager
{
    public static float score = 0;
    public static UnityEvent OnScoreChange = new UnityEvent();
    
    public static float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            OnScoreChange.Invoke();
        }
    }

    
}
