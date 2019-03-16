using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManagerScene00 : MonoBehaviour
{
    public PlayerSaves _playerSaves;
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            NextScene();
    }
    public void CallDefault()
    {
        _playerSaves.SetDefault();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(1);        
    }
}
