using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAccessManager : MonoBehaviour
{
    public GameObject[] Row1;
    public GameObject[] Row2;
    public PlayerSaves _playerSaves;
    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < _playerSaves.Row1; i++)
            MakeAvalible(Row1[i]);
        for (i = 0; i < _playerSaves.Row2; i++)
            MakeAvalible(Row1[i]);
    }
    void MakeAvalible(GameObject obj)
    {
        //obj.GetComponent<Image>();
    }
}
