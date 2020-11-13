using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
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
