/*
Name: Nate Stern
Date: 11/9/20
Desc: Powerup that adds an additional bullet for 5 seconds on pickup
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //load a scene specified by sceneName (used by button in menu)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //quit game in standalone or editor mode
    public void QuitGame()
    {
#if UNITY_EDITOR
        //editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //standalone
        Application.Quit();
#endif    

    }
}