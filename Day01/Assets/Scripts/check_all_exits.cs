using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_all_exits : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject   exit_blue;
    public GameObject   exit_red;
    public GameObject   exit_yellow;

    // Update is called once per frame
    void Update()
    {
        if (exit_blue.GetComponent<exit_check>().exit
        && exit_red.GetComponent<exit_check>().exit
        && exit_yellow.GetComponent<exit_check>().exit)
            Debug.Log("Level finished");
    }
}
