using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public PlayerSaves _playerSaves;
    public Sonic SonicX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SonicX.isDead)
            PlayerPrefs.SetInt("Death", _playerSaves.Death + 1);
    }
    private void OnDisable()
    {
        if (SonicX.rings > _playerSaves.Score)
            PlayerPrefs.SetInt("Score", SonicX.rings);
    }
}
