using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LeveltoLoad = "Alpha build";
    public void Play()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
    public void Exit()
    {
        Debug.Log("Closing...");
        Application.Quit();
    }
}
