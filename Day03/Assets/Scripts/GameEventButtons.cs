using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEventButtons : MonoBehaviour
{
    public GameObject text;
    void Start()
    {
        Time.timeScale = 0;
    }
    public void PlayButton()
    {
        Time.timeScale = 1;
        text.GetComponent<Text>().text = "SPEED : 1X";
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        text.GetComponent<Text>().text = "PAUSED";
    }
    public void PlayX2Button()
    {
        Time.timeScale = 2;
        text.GetComponent<Text>().text = "SPEED : 2X";
    }
    public void PlayX4Button()
    {
        Time.timeScale = 4;
        text.GetComponent<Text>().text = "SPEED : 4X";
    }
}
