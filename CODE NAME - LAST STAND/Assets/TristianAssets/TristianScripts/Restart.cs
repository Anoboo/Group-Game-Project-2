using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // This gives the restart button the ability to restart the game.
    public void RestartGame(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
