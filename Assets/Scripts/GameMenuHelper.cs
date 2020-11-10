using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuHelper : MonoBehaviour
{
    bool paused = false;
    GameObject quitButton;
    GameObject pauseText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Start()
    {
        pauseText = GameObject.Find("Pause Text");
        quitButton = GameObject.Find("Quit Button");
        quitButton.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Pause()
    {
        Debug.Log("Pause");
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        quitButton.SetActive(paused);
        pauseText.SetActive(!paused);
    }
}
