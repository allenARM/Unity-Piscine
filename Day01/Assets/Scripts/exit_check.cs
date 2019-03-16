using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_check : MonoBehaviour
{
    public GameObject   target;
    public bool         exit;

    void Start()
    {
        exit = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == target.name)
            exit = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == target.name)
            exit = false;
    }
}
