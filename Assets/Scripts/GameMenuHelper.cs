/*
Name: Nate Stern
Date: 11/9/20
Desc: Loads menu and game scene and switching between with pausing
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuHelper : MonoBehaviour
{
    bool paused = false;
    GameObject quitButton;
    GameObject pauseText;

    private void Update()
    {
        //if escape key is pressed pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Start()
    {
        //get texts and turn off the quit button
        pauseText = GameObject.Find("Pause Text");
        quitButton = GameObject.Find("Quit Button");
        quitButton.SetActive(false);
    }

    public void Quit()
    {
        //loads into menu
        SceneManager.LoadScene("Main Menu");
    }

    private void Pause()
    {
        //flip the pause
        paused = !paused;
        //freeze game or continue
        Time.timeScale = paused ? 0 : 1;
        //swap quit button and pausetext active state
        quitButton.SetActive(paused);
        pauseText.SetActive(!paused);
    }
}
