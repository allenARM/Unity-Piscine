using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayBut : MonoBehaviour
{
    public void LoadPlay()
    {
        Debug.Log("Loading Start level");
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Debug.Log("Exiting App");
        Application.Quit();
    }
}
