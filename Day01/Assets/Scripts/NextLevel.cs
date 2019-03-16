using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public GameObject   exit_blue;
    public GameObject   exit_red;
    public GameObject   exit_yellow;

    public int        what_to_load;

    // Update is called once per frame
    void Update()
    {
        if (exit_blue.GetComponent<exit_check>().exit
        && exit_red.GetComponent<exit_check>().exit
        && exit_yellow.GetComponent<exit_check>().exit)
            SceneManager.LoadScene(what_to_load);
    }
}
