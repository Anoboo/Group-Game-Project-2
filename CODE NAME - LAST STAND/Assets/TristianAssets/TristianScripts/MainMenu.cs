using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LeveltoLoad;
    private string ControlScreen = "ControlScreen";
    public void Play()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
    public void Exit()
    {
        Debug.Log("Closing...");
        Application.Quit();
    }
    public void Controls()
    {
        SceneManager.LoadScene(ControlScreen);
    }
}
