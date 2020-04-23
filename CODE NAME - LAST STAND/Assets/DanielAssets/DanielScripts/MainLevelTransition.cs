using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevelTransition : MonoBehaviour
{
    public string LeveltoLoad = "MainLevelUpdated";
    public void Continue()
    {
        SceneManager.LoadScene(LeveltoLoad);
    }
    public void Exit()
    {
        Debug.Log("Closing...");
        Application.Quit();
    }
}
