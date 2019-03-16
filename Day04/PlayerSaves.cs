using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSaves : MonoBehaviour
{
    public int Score;
    public int Death;
    public int Row1;
    public int Row2;

    void Start()
    {
        GetData();
    }
    public void GetData()
    {
        Score = PlayerPrefs.GetInt("Score");
        Death = PlayerPrefs.GetInt("Death");
        Row1 = PlayerPrefs.GetInt("Row1");
        Row2 = PlayerPrefs.GetInt("Row2");
    }
    public void SetDefault()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Death", 0);
        PlayerPrefs.SetInt("Row1", 1);
        PlayerPrefs.SetInt("Row2", 1);
        GetData();
    }
}
