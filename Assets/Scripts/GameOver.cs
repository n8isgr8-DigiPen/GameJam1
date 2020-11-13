using UnityEngine;
using System.Collections;
/*
Name: Evan Anderson
Date: 11/12/2020
Desc: Game Over
*/
public class GameOver : MonoBehaviour
{
    [Tooltip("What Gameobject in the Hirearchy is the end panel")]
    public GameObject EndScreen;
    private void Start()
    {
        Time.timeScale = 1;
        
    }
    
    public void triggerMe()
    {
        EndScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
