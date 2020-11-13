using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
Name: Evan Anderson
Date: 11/12/2020
Desc: Control End Buttons
*/
public class EndButtons : MonoBehaviour
{
    
    public void menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void restart()
    {
        SceneManager.LoadScene("Game");
    }
}
